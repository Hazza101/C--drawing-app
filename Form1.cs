using System;
using System.CodeDom;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GrafPack.AppManager;
using GrafPack.Shapes;
using GrafPack.Transformations;
using Microsoft.VisualBasic;


namespace GrafPack
{
    public partial class GrafPack : Form
    {

        private MenuStrip mainMenu;
        private bool selectSquareStatus = true;
        private bool selectTriangleStatus = false;
        private List<PointF> points = new List<PointF>();

        private AppState appState = new AppState();
        
        private List<ToolStripMenuItem> buttonList = new List<ToolStripMenuItem>();
        
        
        
        private Point one;
        private Point two;
        private Shortcuts shortcuts = new Shortcuts();

        public GrafPack()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.White;
            this.DoubleBuffered = true;

            

            

            Matrix lol = new Matrix();
            mainMenu  = new MenuStrip();
            ToolStripMenuItem createItem = new ToolStripMenuItem();
            this.buttonList.Add(createItem);
            ToolStripMenuItem selectItem = new ToolStripMenuItem();
            this.buttonList.Add(selectItem);
            ToolStripMenuItem deleteItem = new ToolStripMenuItem();
            this.buttonList.Add(deleteItem);
            ToolStripMenuItem transformItem = new ToolStripMenuItem();
            this.buttonList.Add(transformItem);
            ToolStripMenuItem exitItem = new ToolStripMenuItem();
            this.buttonList.Add(exitItem);
            selectItem.Text = "&Select";
            createItem.Text = "&Create";
            deleteItem.Text = "&Delete";
            transformItem.Text = "&Transform";
            exitItem.Text = "&Exit";

            
            // Create Items
            ToolStripMenuItem squareItem = new ToolStripMenuItem();
            this.buttonList.Add(squareItem);
            ToolStripMenuItem triangleItem = new ToolStripMenuItem();
            this.buttonList.Add(triangleItem);
            ToolStripMenuItem circleItem = new ToolStripMenuItem();
            this.buttonList.Add(circleItem);
            ToolStripMenuItem rectangleItem = new ToolStripMenuItem();
            this.buttonList.Add(rectangleItem);
            ToolStripMenuItem ellipseItem = new ToolStripMenuItem();
            this.buttonList.Add(ellipseItem);
            ToolStripMenuItem polygonItem = new ToolStripMenuItem();
            this.buttonList.Add(polygonItem);
            triangleItem.Text = "&Triangle";
            squareItem.Text = "&Square";
            circleItem.Text = "&Circle";
            rectangleItem.Text = "&Rectangle";
            ellipseItem.Text = "&Ellipse";
            polygonItem.Text = "&Polygon";

            // Transform Items
            ToolStripMenuItem rotateItem = new ToolStripMenuItem();
            this.buttonList.Add(rotateItem);
            ToolStripMenuItem translateItem = new ToolStripMenuItem();
            this.buttonList.Add(translateItem);
            ToolStripMenuItem reflectItem = new ToolStripMenuItem();
            this.buttonList.Add(reflectItem);
            ToolStripMenuItem scaleItem = new ToolStripMenuItem();
            this.buttonList.Add(scaleItem);

            rotateItem.Text = "&Rotate";
            translateItem.Text = "&Translate";
            reflectItem.Text = "&Reflect";
            scaleItem.Text = "&Scale";



            
            
            
            
            
            
            mainMenu.Items.Add(createItem);
            mainMenu.Items.Add(selectItem);
            mainMenu.Items.Add(deleteItem);
            mainMenu.Items.Add(transformItem);
            mainMenu.Items.Add(exitItem);
            
            // adding creating options to create button
            createItem.DropDownItems.Add(squareItem);
            createItem.DropDownItems.Add(triangleItem);
            createItem.DropDownItems.Add(circleItem);
            createItem.DropDownItems.Add(rectangleItem);
            createItem.DropDownItems.Add(ellipseItem);
            createItem.DropDownItems.Add(polygonItem);

            // adding transforming options
            transformItem.DropDownItems.Add(rotateItem);
            transformItem.DropDownItems.Add(translateItem);
            transformItem.DropDownItems.Add(reflectItem);
            transformItem.DropDownItems.Add(scaleItem);

            // handlers
            //selectItem.Click += new System.EventHandler(this.setMode);
            squareItem.Click += new System.EventHandler(this.setMode);
            triangleItem.Click += new System.EventHandler(this.setMode);
            circleItem.Click += new System.EventHandler(this.setMode);
            ellipseItem.Click += new System.EventHandler(this.setMode);
            rectangleItem.Click += new System.EventHandler(this.setMode);
            polygonItem.Click += new System.EventHandler(this.setMode);

            selectItem.Click += new System.EventHandler(this.setMode);
            deleteItem.Click += new System.EventHandler(this.setMode);

            translateItem.Click += new System.EventHandler(this.setMode);
            scaleItem.Click += new System.EventHandler(this.setMode);
            rotateItem.Click += new System.EventHandler(this.setMode);
            reflectItem.Click += new System.EventHandler(this.setMode);

            exitItem.Click += new System.EventHandler(this.exitProgram);

            foreach(ToolStripMenuItem foo in this.buttonList)
            {
                if (shortcuts.HasShortcut(foo.Text))
                {
                    Keys shortcut = shortcuts.GetShortCutKeys(foo.Text);
                    
                    foo.ShortcutKeys = (shortcut);
                    
                }
                
            }

            this.Controls.Add(mainMenu);
            this.MouseClick += mouseClick;
            this.MouseMove += mouseMove;
        }

        private void exitProgram(object sender, EventArgs e)
        {
            bool isExit = MessageBox.Show(
                "Are you sure you want to exit?",
                "Exit Program",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            ) == DialogResult.Yes;
            if (isExit)
            {
                Application.Exit();
            }
            
            
        }

        private void setMode(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                string itemName = item.Text;
                bool result = this.appState.SetState(itemName);
                if (!result)
                {
                    MessageBox.Show("Something went wrong");
                }
                this.Invalidate();
            
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            

            appState.DrawShapes(g);
            
            
        }

        
        
        
        
        private void mouseMove(object sender, MouseEventArgs e)
        {
            
            if (appState.isTranslating)
            {
                this.appState.TranslateSelectedShape(e.Location);
                this.Invalidate();
            } else if (appState.isRotating)
            {
                this.appState.RotateSelectedShape(e.Location);
                this.Invalidate();
            } else if (appState.isScaling)
            {
                this.appState.ScaleSelectedShape(e.Location);
                this.Invalidate();
            } else if (appState.createMode)
            {
                if (this.appState.PointsCount() > 0)
                {
                    this.appState.DrawRubberandingShape(e.Location);
                    this.Invalidate();
                }
                
            }
            
        }
        
        private void mouseClick(object sender, MouseEventArgs e)
        {
            if (appState.reflectMode)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (appState.AddPointToLine(e.Location))
                    {
                        appState.ReflectSelectedShape();
                        appState.ResetLine();
                        this.Invalidate();
                        
                    } else
                    {
                        this.Invalidate();
                    }

                } else if (e.Button == MouseButtons.Right)
                {
                    appState.ResetLine();
                }
            } else if (appState.translateMode)
            {
                if (e.Button == MouseButtons.Left)
                {
                    appState.ToggleTranslating(e.Location);
                }
            } else if (appState.scaleMode)
            {
                if (e.Button == MouseButtons.Left)
                {
                    appState.ToggleScaling(e.Location);
                }
            } else if (appState.rotateMode)
            {
                if (e.Button == MouseButtons.Left)
                {
                    appState.ToggleRotating(e.Location);
                }
            }
            else if (appState.selectMode)
            {
                if (e.Button == MouseButtons.Left)
                {
                    appState.SelectShape(e.Location);
                    this.Invalidate();
                }

            } else if (appState.createMode)
            {
                if (e.Button == MouseButtons.Left)
                {
                    appState.AddPoint(e.Location);
                    // out of date
                    if (appState.IsShapeReady())
                    {
                        appState.CreateShape();
                        this.Invalidate();
                        
                    }
                }

                if (e.Button == MouseButtons.Right)
                {
                    if (appState.polygonMode)
                    {
                        //appState.polygonDone = true;
                        if (appState.PointsCount() > 0)
                        {
                            appState.CreateShape();
                            this.Invalidate();
                        }
                        
                    } else
                    {
                        appState.ResetPoints();
                        this.Invalidate();
                    }
                }
                
                
                
                
                
                
            }
            
            
            
        }
    }
    
    
    
    
    
}


