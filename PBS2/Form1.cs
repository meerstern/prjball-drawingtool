using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;
using System.Collections;         
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


namespace PBS2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormWidth = this.Size.Width;
            FormHeight = this.Size.Height-20;
            PosNum = 0;
            PosR = 2;
            IntervalBox.Text = (10).ToString();
            RepeatBox.Text = (5).ToString();
            OffsetBox.Text = (0).ToString();

            _bitmap = new Bitmap(pic.Width, pic.Height);
            _bitmap.MakeTransparent();
            DrawAxis();
            pic.Image = _bitmap;       
            
            canvas.Parent = this;
            canvas.BringToFront();

            pic.MouseMove += new System.Windows.Forms.MouseEventHandler(Form1_MouseMove);
            pic.MouseDown += new System.Windows.Forms.MouseEventHandler(Form1_MouseDown);
            pic.MouseUp += new System.Windows.Forms.MouseEventHandler(Form1_MouseUp);
            pic.DragDrop += new System.Windows.Forms.DragEventHandler(Form1_DragDrop);
            pic.AllowDrop = true;

            PosStatus.Text = "0 0";
            FixedPos.Text = "";
            PosCount.Text = "0";
            LSRbtn.BackColor = Color.Yellow;           
        }
        ArrayList PosDataL = new ArrayList();
        ArrayList PosDataX = new ArrayList();
        ArrayList PosDataY = new ArrayList();

        ArrayList DataL = new ArrayList();
        ArrayList DataX = new ArrayList();
        ArrayList DataY = new ArrayList();

        int FormWidth;
        int FormHeight;
        int PosNum;
        int PosR;//Radius of point 
        Bitmap _bitmap = null;
        Point oldLocation = new Point();
        Point OldGetPos = new Point();
        ShapeContainer canvas = new ShapeContainer();
        string FName="";
        string FileName = "";
        string FDirec = "";

        int IntervalVal = 0;
        int RepeatVal = 0;
        int OffsetVal = 0; 
        string version = "0.0.1";
        bool LsrStatus = true;
        bool SavedData = true;
        bool isDrag = false;
        int isDragIndex = 0;
        int y_offset = -28; //Y Offset
        
       


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            
               switch(e.Button){
                   case MouseButtons.Left:
                       MouseLeft(sender, e);
                       break;
                   case MouseButtons.Right:
                       MouseRight();
                       break;
                   default:
                       break;

               }

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
         
            
            if (e.Button==MouseButtons.Left&&isDrag == true) {
                Point GetPos = new Point();
                GetPos.X = e.Location.X - 0;
                GetPos.Y = e.Location.Y + y_offset;

                PosDataX[isDragIndex] = GetPos.X;
                PosDataY[isDragIndex] = GetPos.Y;


                //Delete All Lines & Dot 
                for (int a = canvas.Shapes.Count; 0 < a; a--)
                {
                    canvas.Shapes.RemoveAt(a - 1);
                }

                ReDraw();

                isDrag = false;
            }
        }

        private void DrawAxis() {

            using (Graphics g = Graphics.FromImage(_bitmap))
            {
                Pen dotline = new Pen(Color.Gray, 1);
                dotline.DashStyle = DashStyle.Dash;

                //Frame
                g.DrawLine(dotline, 50, 50, FormWidth - 50, 50);
                g.DrawLine(dotline, FormWidth - 50, 50, FormWidth - 50, FormHeight - 50);
                g.DrawLine(dotline, 50, FormHeight - 50, FormWidth - 50, FormHeight - 50);
                g.DrawLine(dotline, 50, 50, 50, FormHeight - 50);

                //AXIS
                g.DrawLine(Pens.Black, 0, FormHeight / 2, FormWidth, FormHeight / 2);
                g.DrawLine(Pens.Black, FormWidth / 2, 0, FormWidth / 2, FormHeight);

            }
        
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
           int PosX=0;
           int PosY=0;

            PosC2P(e.Location.X,e.Location.Y, ref PosX, ref PosY);    
            PosStatus.Text =PosX.ToString() + " " + PosY.ToString();
#if DEBUG
            FixedPos.Text = "  " + e.Location.X.ToString() + " " + e.Location.Y.ToString();
#endif
            PosCount.Text = PosNum.ToString();
                    }


        private void MouseLeft(object sender, MouseEventArgs e)
        {

            OvalShape thePoint = new OvalShape();
            Point GetPos = new Point();
            GetPos.X = e.Location.X - 0;// -PosR / 2;
            GetPos.Y = e.Location.Y - 28;// -PosR / 2;     
                        
            /* Position fix Mode  */
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                for (int i = 0; i < PosNum; i++)
                {
                    if (System.Math.Abs((int)PosDataX[i] - GetPos.X) < 3 && System.Math.Abs((int)PosDataY[i] - GetPos.Y) < 3)
                    {
                        isDragIndex = i;
                        isDrag = true;
                    }
                }
                return; 
            }
            else
            {
                isDrag = false;
            }
            
            /* Normal Mode */
                   

            //Shift Key -> Laser ON
            if ((Control.ModifierKeys & Keys.Shift) != Keys.Shift && LsrStatus==true)
            {
                DrawPoint(GetPos, Color.WhiteSmoke);
                if (PosNum != 0) DrawLine(OldGetPos, GetPos, Color.WhiteSmoke);
                PosDataL.Add(1);
            }
            //Laser OFF
            else {
                DrawPoint(GetPos, Color.Black);
                if (PosNum != 0) DrawLine(OldGetPos, GetPos, Color.Black);
                PosDataL.Add(0);
            }
  
            PosDataX.Add(GetPos.X);
            PosDataY.Add(GetPos.Y);

            PosNum++;
            OldGetPos = GetPos;
            oldLocation = e.Location;
            SavedData = false;        
        
        }

        private void MouseRight() {

            if (PosNum <= 0) return;
            PosDataL.RemoveAt(PosNum - 1);
            PosDataX.RemoveAt(PosNum - 1);
            PosDataY.RemoveAt(PosNum - 1);

            //Delete ALL Lines & Dot
            for (int a = canvas.Shapes.Count; 0 < a; a--)
            {
                canvas.Shapes.RemoveAt(a - 1);
            }

            PosNum--;

            ReDraw();
            SavedData = false;
   
        }

        
      private void DrawPoint(Point Pos, Color Col){

          OvalShape thePoint = new OvalShape();
          thePoint.Location = Pos;
          canvas.Parent = this;
          thePoint.Parent = canvas;
          thePoint.Size = new System.Drawing.Size(PosR, PosR);
          thePoint.BackColor = Col;
          thePoint.BackStyle = BackStyle.Opaque;
          thePoint.Name = "thePoint" + PosNum.ToString();
          thePoint.BorderColor = Col;
          thePoint.Enabled = false;
          canvas.Invalidate();
      
      }

      private void DrawLine(Point StartPos, Point EndPos, Color Col) {

          LineShape PLine = new LineShape();
          canvas.Parent = this;
          PLine.Parent = canvas;
          PLine.StartPoint = StartPos;
          PLine.EndPoint = EndPos;
          PLine.BorderColor = Col;
          PLine.Enabled = false;
          canvas.Invalidate();      
      
      }

      private void ReDraw() {

          if (PosNum == 0) return;

          //Re-Draw
          Point GetPos = new Point();
          GetPos.X = (int)PosDataX[0];
          GetPos.Y = (int)PosDataY[0];

          if ((int)PosDataL[0] == 1) DrawPoint(GetPos, Color.WhiteSmoke);
          else DrawPoint(GetPos, Color.Black);

          for (int i = 0; i < PosNum - 1; i++)
          {
              Point Pos1 = new Point();
              Point Pos2 = new Point();

              Pos1.X = (int)PosDataX[i];
              Pos1.Y = (int)PosDataY[i];

              Pos2.X = (int)PosDataX[i + 1];
              Pos2.Y = (int)PosDataY[i + 1];

              if ((int)PosDataL[i + 1] == 1)
              {
                  DrawLine(Pos1, Pos2, Color.WhiteSmoke);
                  DrawPoint(Pos2, Color.WhiteSmoke);
              }
              else
              {
                  DrawLine(Pos1, Pos2, Color.Black);
                  DrawPoint(Pos2, Color.Black);
              }
              oldLocation = Pos2;
              OldGetPos = Pos2;

          }
          if (PosNum == 1) OldGetPos = GetPos;
      }


      //Save 
      private void saveToolStripMenuItem_Click(object sender, EventArgs e)
      {
          if (FName == "")
          {
              saveAsToolStripMenuItem_Click(sender, e);
              return;
          }
          else {
              System.IO.FileStream stream = new System.IO.FileStream(   FName, 
                                                                        System.IO.FileMode.Create, 
                                                                        System.IO.FileAccess.Write);
              SaveData(stream);
              SavedData = true;
          }
          


      }
      //Save as 
      private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
      {
          SaveFileDialog sfd = new SaveFileDialog();
          if (FileName!="") sfd.FileName = FileName;
          sfd.Filter ="PBS file(*.pbs)|*.pbs|All Files(*.*)|*.*";
          sfd.FilterIndex = 1;
          sfd.Title = "Save As";
          sfd.RestoreDirectory = true;
          sfd.OverwritePrompt = true;
          sfd.CheckPathExists = true;

         
          if (sfd.ShowDialog() == DialogResult.OK)
          {
              Console.WriteLine(sfd.FileName);
              FName = sfd.FileName;
              FileName = System.IO.Path.GetFileName(FName);
              FDirec = System.IO.Path.GetDirectoryName(FName);
              System.IO.Stream stream;
              stream = sfd.OpenFile();
              SaveData(stream);
              SavedData = true;
          }
          

      }

      private void ConvertData() {

          if (PosNum == 0) return;
          GetSetValue();         

          for (int i = 0; i < PosNum - 1; i++) {

              
              if (System.Math.Abs((int)PosDataX[i] - (int)PosDataX[i + 1]) > IntervalVal ||
                  System.Math.Abs((int)PosDataY[i] - (int)PosDataY[i + 1]) > IntervalVal)
              {
                  
                  int DivNumX = System.Math.Abs((int)PosDataX[i] - (int)PosDataX[i + 1]) / IntervalVal;
                  int DivNumY = System.Math.Abs((int)PosDataY[i] - (int)PosDataY[i + 1]) / IntervalVal;
                  int DivNum=1;

                  
                  if (DivNumX > DivNumY) DivNum = DivNumX;
                  else DivNum = DivNumY;


                  int IntValX = (int)PosDataX[i + 1] - (int)PosDataX[i];
                  int IntValY = (int)PosDataY[i + 1] - (int)PosDataY[i];

                  int dX, dY;

                  if (DivNum != 0)
                  {
                      dX = IntValX / DivNum;
                      dY = IntValY / DivNum;
                  }
                  else {
                      dX = IntValX ;
                      dY = IntValY ;
                  }


                  for (int j = 0; j < DivNum ;j++ )
                  {
                      if ( j==0) {
                          DataL.Add(PosDataL[i]);
                      } else {
                          DataL.Add(PosDataL[i + 1]);
                      }
                      
                      
                      DataX.Add((int)PosDataX[i]+dX*j);
                      DataY.Add((int)PosDataY[i]+dY*j);

                  }

              }
              else {
                  DataL.Add(PosDataL[i]);
                  DataX.Add(PosDataX[i]);
                  DataY.Add(PosDataY[i]);
              }
                        
          }

          DataL.Add(PosDataL[PosNum - 1]);
          DataX.Add(PosDataX[PosNum - 1]);
          DataY.Add(PosDataY[PosNum - 1]);
      
      }

   
      //CSV →Point
      private void PosC2P(int cx, int cy,ref int px,ref int py) {
          px = (cx - FormWidth / 2);
          py = (-cy + FormHeight / 2);
      }
      //Point→CSV
      private void PosP2C(int px, int py, ref int cx, ref int cy) {
          cx = px + FormWidth / 2;
          cy = -py + FormHeight / 2;
      }

      private void ExportCSV(string num) {

          try{

              if (PosNum == 0) return;

              if (DataL.Count > 200) {

                  DialogResult result = MessageBox.Show("ポイント数が200点を超えています\r\n強制的にエクスポートしますか",
                  "ProjectionBall",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Exclamation,
                  MessageBoxDefaultButton.Button2);
                  if (result == DialogResult.No) return;
              
              }

              var append = false;//NewFile
              int l=0,x=0,y=0;
              string file="";
              
              //frame mode or not
              if(num.Substring(0,1)!="f"){
                  if (FDirec != "") file = FDirec + "\\data"+ num+".csv";
                  else file = "data"+ num +".csv";
              }
              else{
                  if (FDirec != "") file = FDirec  + num + ".csv";
                  else file =  num + ".csv";
              }


              using (var sw = new System.IO.StreamWriter(file, append))
              {
                  //Set repeat num
                  sw.WriteLine("{0},{1},{2}", RepeatVal, 0, 0);

                  for (int i = 0; i < DataL.Count;i++)
                  {


                      if (i - OffsetVal >= 0)
                      {
                          l = (int)DataL[i - OffsetVal];
                      }
                      else if (0 <= (i - OffsetVal + DataL.Count ))
                      {
                          l = (int)DataL[i - OffsetVal + DataL.Count ];
                      }
                      else
                      {
                          l = (int)DataL[i];
                      }

                      PosC2P((int)DataX[i], (int)DataY[i],ref x, ref y);
                      sw.WriteLine("{0},{1},{2}", l, x, y + y_offset);
                  }
              }
              
              string dir = System.IO.Path.GetDirectoryName(file);
              string msg;
              

              //frame mode or not
              if (num.Substring(0, 1) != "f")
              {
                   msg = "CSVファイルが出力されました" + "\n\r"
                           + "ディレクトリ: " + dir + "\n\r"
                           + "ファイル名: " + "data" + num + ".csv" + "\n\r"
                           + "ポイント数: " + (int)(DataL.Count) + "個";
              }
              else
              {
                   msg = "CSVファイルが出力されました" + "\n\r"
                            + "ディレクトリ: " + dir + "\n\r"
                            + "ファイル名: "  + num + ".csv" + "\n\r"
                            + "ポイント数: " + (int)(DataL.Count) + "個";
              }
              MessageBox.Show(msg,
                 "ProjectionBall",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information,
                 MessageBoxDefaultButton.Button1);

          }
          catch (System.Exception e){
              //File Open Error
              System.Console.WriteLine(e.Message);
          }  
      
      }

      //Read Setting Data
      private void GetSetValue() {

          IntervalVal = int.Parse(IntervalBox.Text);
          RepeatVal = int.Parse(RepeatBox.Text);
          OffsetVal = int.Parse(OffsetBox.Text);
          if (IntervalVal == 0) IntervalVal = 1;
          if (RepeatVal == 0) IntervalVal = 5;
          if (OffsetVal < 0) OffsetVal = 0;
      
      }
    　//File Save
      private void SaveData(System.IO.Stream stream)
      {
         
          if (stream != null)
          {
              GetSetValue();
              System.IO.StreamWriter sw = new System.IO.StreamWriter(stream);
              sw.WriteLine("{0},{1}", "Version", version);
              sw.WriteLine("{0},{1}", "Interval", IntervalVal);
              sw.WriteLine("{0},{1}", "Repeat", RepeatVal);
              sw.WriteLine("{0},{1}", "Offset", OffsetVal);

              for (int i = 0; i < PosNum ; i++)
              {
                  sw.WriteLine("{0},{1},{2}", (int)PosDataL[i], (int)PosDataX[i], (int)PosDataY[i]);
              }
              sw.Close();
              stream.Close();
          }

      }
      //Read Saved data
      private void LoadData(System.IO.Stream stream)
      {
          if (stream != null)
          {
              GetSetValue();
              System.IO.StreamReader sw = new System.IO.StreamReader(stream);
              int count = 0;

              PosNum = 0;
              PosDataL.Clear();
              PosDataX.Clear();
              PosDataY.Clear();

              while (!sw.EndOfStream) {

                  var line = sw.ReadLine();
                  var values = line.Split(',');

                  if (line!=null) { 

                      if(values[0]=="Interval"){
                          IntervalBox.Text = values[1];
                      }
                      else if (values[0] == "Repeat"){
                          RepeatBox.Text = values[1]; 
                      }
                      else if (values[0] == "Offset")
                      {
                          OffsetBox.Text = values[1];
                      }
                      else if (values[0] == "1"){
                          PosDataL.Add(1);
                          PosDataX.Add(int.Parse(values[1]));
                          PosDataY.Add(int.Parse(values[2]));
                          count++;
                      }
                      else if (values[0] == "0"){
                          PosDataL.Add(0);
                          PosDataX.Add(int.Parse(values[1]));
                          PosDataY.Add(int.Parse(values[2]));
                          count++;
                      }
                  }
  
              
              }

              sw.Close();
              stream.Close();

              PosNum = count;
              ReDraw();
          }
      
      
      }
       //File Open
      private void loadStripMenuItem2_Click(object sender, EventArgs e)
      {
          newToolStripMenuItem_Click( sender,  e);
          
          OpenFileDialog sfd = new OpenFileDialog();
          if (FileName != "") sfd.FileName = FileName;
          sfd.Filter = "PBS file(*.pbs)|*.pbs|All Files(*.*)|*.*";
          sfd.FilterIndex = 2;
          sfd.Title = "Save As";
          sfd.RestoreDirectory = true;
          sfd.CheckPathExists = true;


          if (sfd.ShowDialog() == DialogResult.OK)
          {
              Console.WriteLine(sfd.FileName);
              FName = sfd.FileName;
              FileName = System.IO.Path.GetFileName(FName);
              FDirec = System.IO.Path.GetDirectoryName(FName);
              System.IO.Stream stream;
              stream = sfd.OpenFile();
              LoadData(stream);
              SavedData = true;
          }
          
      }

      private void LSRbtn_Click(object sender, EventArgs e)
      {
          if (LsrStatus == false) {
              LSRbtn.BackColor = Color.Yellow;
              LSRbtn.Text ="レーザーON" ;
              LsrStatus = true;
          }
          else {
              LSRbtn.BackColor = Color.Gray;
              LSRbtn.Text = "レーザーOFF";
              LsrStatus = false;
          }
      }

      private void exportToolStripMenuItem_Click(object sender, EventArgs e)
      {
     
      }

      private void newToolStripMenuItem_Click(object sender, EventArgs e)
      {
          
          
          if(PosNum!=0 && SavedData==false){
              DialogResult result = MessageBox.Show("保存されていないデータは削除されます。\n\r描画を新規作成しますか？",
                   "ProjectionBall",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Exclamation,
                   MessageBoxDefaultButton.Button2);
              if (result == DialogResult.No) return;
          }

          //Delete ALL Lines & Dot
          for (int a = canvas.Shapes.Count; 0 < a; a--)
          {
              canvas.Shapes.RemoveAt(a - 1);
          }

          PosNum = 0;
          PosDataL.Clear();
          PosDataX.Clear();
          PosDataY.Clear();
          SavedData = true;

          
      }
      //Clear background
      private void backclearToolStripMenuItem_Click(object sender, EventArgs e)
      {
         
          _bitmap = null;
          _bitmap = new Bitmap(pic.Width, pic.Height);
          _bitmap.MakeTransparent();
          DrawAxis();
          pic.Image = _bitmap;
          canvas.Invalidate();   
      }

      //ADD background 
      private void backloadToolStripMenuItem_Click(object sender, EventArgs e)
      {
          //Clear background
          backclearToolStripMenuItem_Click(sender, e);
          
          OpenFileDialog sfd = new OpenFileDialog();
          //sfd.FileName = "data0.pbs";
          sfd.Filter = "BMP file(*.bmp)|*.bmp|JPG file(*.jpg)|*.jpg|All Files(*.*)|*.*";
          sfd.FilterIndex = 3;
          sfd.Title = "Save As";
          sfd.RestoreDirectory = true;
          sfd.CheckPathExists = true;


          if (sfd.ShowDialog() == DialogResult.OK)
          {

              ColorMatrix mx = new ColorMatrix();
              mx[0, 0] = 1;
              mx[1, 1] = 1;
              mx[2, 2] = 1;
              mx[3, 3] = 0.5F;
              mx[4, 4] = 1;
              ImageAttributes attr = new ImageAttributes();
              attr.SetColorMatrix(mx);
              
              System.Drawing.Image img = System.Drawing.Image.FromFile(sfd.FileName);
             
              Graphics g = Graphics.FromImage(_bitmap);
              //g.DrawImage(img, 0, 0, img.Width, img.Height);
              g.DrawImage(img, new Rectangle(FormWidth / 2-img.Width/2, FormHeight / 2-img.Height/2,
                                             img.Width, img.Height),
                            0, 0, 
                            img.Width, img.Height, 
                            GraphicsUnit.Pixel, attr);
              //FormWidth,FormHeight
              DrawAxis();
              pic.Image = _bitmap;
              canvas.Invalidate();   
             
             
          }
      }



      private void Form1_FormClosing(object sender, FormClosingEventArgs e)
      {
          if (PosNum == 0) return;
          if (SavedData==false)
          {
              DialogResult result=MessageBox.Show("保存されていないデータがあります。\r\n終了しますか?",
                                                    "ProjectionBall", 
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Information);
              if (result == DialogResult.No) e.Cancel=true;
          }
      }

      private void toolStripMenuItem2_Click(object sender, EventArgs e)
      {
          MouseRight();
      }

      private void data0csvToolStripMenuItem_Click(object sender, EventArgs e)
      {
          GetSetValue();
          DataL.Clear();
          DataX.Clear();
          DataY.Clear();
          ConvertData();
          ExportCSV("0");
      }

      private void data1csvToolStripMenuItem_Click(object sender, EventArgs e)
      {
          GetSetValue();
          DataL.Clear();
          DataX.Clear();
          DataY.Clear();
          ConvertData();
          ExportCSV("1");
      }

      private void data2csvToolStripMenuItem_Click(object sender, EventArgs e)
      {
          GetSetValue();
          DataL.Clear();
          DataX.Clear();
          DataY.Clear();
          ConvertData();
          ExportCSV("2");
      }

      private void data3csvToolStripMenuItem_Click(object sender, EventArgs e)
      {
          GetSetValue();
          DataL.Clear();
          DataX.Clear();
          DataY.Clear();
          ConvertData();
          ExportCSV("3");
      }

      private void Form1_DragDrop(object sender, DragEventArgs e)
      {
          // Drag & Drop
          string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
          newToolStripMenuItem_Click(sender, e);
          FName = files[0];
  
          string stExtension = System.IO.Path.GetExtension(FName); // 拡張子を取得する

          if (stExtension==".pbs") {

              System.IO.Stream stream = new System.IO.FileStream(FName,
                                                                 System.IO.FileMode.Open,
                                                                 System.IO.FileAccess.Read);
              FileName = System.IO.Path.GetFileName(FName);
              FDirec = System.IO.Path.GetDirectoryName(FName);
              //System.IO.Stream stream;
              //stream = stream.OpenFile();
              LoadData(stream);
              SavedData = true;        
                 
          }
 
      }

      private void Form1_DragEnter(object sender, DragEventArgs e)
      {
          if (e.Data.GetDataPresent(DataFormats.FileDrop))
          {
              e.Effect = DragDropEffects.Copy;
          }
          else
          {
              e.Effect = DragDropEffects.None;
          }
      }

      private void framecsvToolStripMenuItem_Click(object sender, EventArgs e)
      {
          GetSetValue();
          DataL.Clear();
          DataX.Clear();
          DataY.Clear();
          ConvertData();
          ExportCSV("frame0");
      }


    }
}
