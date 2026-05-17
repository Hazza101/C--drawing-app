using System.Drawing.Drawing2D;
using GrafPack.Shapes;
using GrafPack.Transformations;
namespace GrafPack.AppManager
{
    public class AppState
    {
        public bool selectMode {get; private set;}
        public bool deleteMode {get; private set;}
        public bool scaleMode {get; private set;}
        public bool translateMode {get; private set;}
        public bool rotateMode {get; private set;}
        public bool reflectMode {get; private set;}
        public bool createMode {get; private set;}
        public bool squareMode {get; private set;}
        public bool triangleMode {get; private set;}
        public bool rectangleMode {get; private set;}
        public bool circleMode {get; private set;}
        public bool polygonMode {get; private set;}
        public bool ellipseMode {get; private set;}
        public bool polygonDone {get; set;}
        private List<PointF> points;
        public List<Shape> shapes = new List<Shape>();
        private Pen blackPen = new Pen(Color.Black);
        private Pen redPen = new Pen(Color.Red, 2);
        private Brush blackBrush = new SolidBrush(Color.Black);
        private Brush redBrush = new SolidBrush(Color.Red);
        private int selectedShapeIdx = -1;
        public bool isTranslating {get; private set;}
        public bool isRotating {get; private set;}
        public bool isScaling {get; private set;}
        private PointF originPoint;
        private float rotateStep = 0.01F;
        private float scaleStep = 0.01F;
        private PointF lineStart;
        private PointF lineEnd;
        private Line reflectionLine = Line.Empty;
        private Pen dashedGreyPen = new Pen(Color.Gray, 2);
        private PointF scalingHook;

        private Pen rubberbandPen = new Pen(Color.Gray);
        private Brush rubberbandBrush = new SolidBrush(Color.Gray);

        public Shape? rubberbandShape = null;
        public AppState()
        {
            selectMode = false;
            deleteMode = false;
            scaleMode = false;
            translateMode = false;
            rotateMode = false;
            reflectMode = false;
            createMode = false;
            squareMode = false;
            triangleMode = false;
            rectangleMode = false;
            circleMode = false;
            polygonMode = false;
            ellipseMode = false;

            polygonDone = false;

            isRotating = false;
            isScaling = false;
            isTranslating = false;

            originPoint = PointF.Empty;
            
            dashedGreyPen.DashStyle = DashStyle.Dash;
            rubberbandPen.DashStyle = DashStyle.Dash;

        }
        public void ResetLine()
        {
            lineStart = PointF.Empty;
            lineEnd = PointF.Empty;
        }
        public bool AddPointToLine(PointF point)
        {
            if (lineStart == PointF.Empty)
            {
                lineStart = point;
                return false;
            }
            lineEnd = point;
            reflectionLine = new Line(lineStart, lineEnd);
            return true;
        }
        public bool TranslateSelectedShape(PointF target)
        {
            if (selectedShapeIdx == -1)
            {
                return false;
            }
            
            
            //ointF center = this.shapes[selectedShapeIdx].GetCenter();
            
            //float angle = (target.X - this.originPoint.X) * this.rotateStep;
            
            Translation.Translate(this.shapes[selectedShapeIdx], originPoint, target);
            originPoint = target;


            return true;
        }
        public bool ScaleSelectedShape(PointF target)
        {
            if (selectedShapeIdx == -1)
            {
                return false;
            }
            
            
            //PointF center = this.shapes[selectedShapeIdx].GetCenter();
            
            PointF scale = new PointF(
                (target.X - this.originPoint.X) * this.scaleStep + 1,
                (target.X - this.originPoint.X) * this.scaleStep + 1
            );
            
            
            Scaling.Scale(this.shapes[selectedShapeIdx], scale, scalingHook);
            originPoint = target;


            return true;
        }
        public bool RotateSelectedShape(PointF target)
        {
            if (selectedShapeIdx == -1)
            {
                return false;
            }
            
            
            PointF center = this.shapes[selectedShapeIdx].GetCenter();
            
            float angle = (target.X - this.originPoint.X) * this.rotateStep;
            
            Rotation.Rotate(this.shapes[selectedShapeIdx], angle, center);
            originPoint = target;


            return true;
        }
        public bool ReflectSelectedShape()
        {
            if (selectedShapeIdx == -1)
            {
                return false;
            }
            
            
            //PointF center = this.shapes[selectedShapeIdx].GetCenter();
            
            //float angle = (target.X - this.originPoint.X) * this.rotateStep;
            
            Reflection.Reflect(this.shapes[selectedShapeIdx], reflectionLine);
            


            return true;
        }
        public void ToggleTranslating(PointF point)
        {
            this.isTranslating = !this.isTranslating;
            this.originPoint = point;
        }
        public void ToggleRotating(PointF point)
        {
            this.isRotating = !this.isRotating;
            this.originPoint = point;
        }
        public void ToggleScaling(PointF point)
        {
            this.isScaling = !this.isScaling;
            this.scalingHook = this.shapes[selectedShapeIdx].GetNearestPoint(point);
            this.originPoint = new PointF(point.X, point.Y);
        }
        public bool SelectShape(PointF point)
        {
            for (int i = 0; i < this.shapes.Count(); i++)
            {
                if (this.shapes[i].Contains(point))
                {
                    this.selectedShapeIdx = i;
                    return true;
                }
            }
            this.selectedShapeIdx = -1;
            return false;
        } 
        public void AddPoint(PointF point)
        {
            this.points.Add(point);
        }
        public int PointsCount()
        {
            return this.points.Count();
        }
        public void ResetPoints()
        {
            this.rubberbandShape = null;
            this.points = new List<PointF>();
        }
        public bool IsShapeReady()
        {
            if (!polygonMode && PointsCount() == 2)
            {
                // MessageBox.Show("first");
                return true;
            } else if (polygonMode && polygonDone)
            {
                MessageBox.Show("second");
                return true;
            }
            // MessageBox.Show("False");
            return false;
        }
        public void CreateShape()
        {
            if (createMode)
            {
                if (triangleMode)
                {
                    this.shapes.Add( new Triangle(this.points[0], this.points[1]));
                    ResetPoints();
                } else if (rectangleMode)
                {
                    this.shapes.Add( new Quadrilateral(this.points[0], this.points[1]));
                    ResetPoints();
                } else if (squareMode)
                {
                    this.shapes.Add( new Square(this.points[0], this.points[1]));
                    ResetPoints();
                } else if (circleMode)
                {
                    this.shapes.Add( new Circle(this.points[0], this.points[1]));
                    ResetPoints();
                } else if (ellipseMode)
                {
                    this.shapes.Add( new Ellipse(this.points[0], this.points[1]));
                    ResetPoints();
                } else if (polygonMode)
                {
                    this.shapes.Add( new Polygon(this.points.ToArray()));
                    ResetPoints();
                }


            } this.rubberbandShape = null;
        }
        public void DrawShapes(Graphics g)
        {
            if (this.reflectionLine != Line.Empty)
            {
                this.reflectionLine.Draw(g, dashedGreyPen);
                this.reflectionLine = Line.Empty;
            }
            
            if (this.rubberbandShape != null)
            {
                if (this.rubberbandShape.drawType.Equals("Pen"))
                {
                   this.rubberbandShape.Draw(g, this.rubberbandPen);

                } else
                {
                    this.rubberbandShape.Draw(g, this.rubberbandBrush);
                }
                    
            }

            for (int i = 0; i < this.shapes.Count(); i++)
            {
                if (this.shapes[i].drawType.Equals("Pen"))
                {
                    if (i == selectedShapeIdx)
                    {
                        this.shapes[i].Draw(g, this.redPen);
                    } else
                    {
                        this.shapes[i].Draw(g, this.blackPen);
                    }
                } else
                {
                    if (i == selectedShapeIdx)
                    {
                        this.shapes[i].Draw(g, this.redBrush);
                    } else
                    {
                        this.shapes[i].Draw(g, this.blackBrush);
                    }
                }
            };
        }
        public bool SetState(string state)
        {
            selectMode = false;
            deleteMode = false;
            scaleMode = false;
            translateMode = false;
            rotateMode = false;
            reflectMode = false;
            createMode = false;
            squareMode = false;
            triangleMode = false;
            rectangleMode = false;
            circleMode = false;
            polygonMode = false;
            ellipseMode = false;
            
            polygonDone = false;

            isRotating = false;
            isScaling = false;
            isTranslating = false;

            ResetLine();
            reflectionLine = Line.Empty;
            scalingHook = PointF.Empty;

            if (state.Equals("&Triangle"))
            {
                this.selectedShapeIdx = -1;
                triangleMode = true;
                points = new List<PointF>();
                createMode = true;
                return true;
            } else if (state.Equals("&Square"))
            {
                this.selectedShapeIdx = -1;
                squareMode = true;
                points = new List<PointF>();
                createMode = true;
                return true;
            } else if (state.Equals("&Rectangle"))
            {
                this.selectedShapeIdx = -1;
                rectangleMode = true;
                points = new List<PointF>();
                createMode = true;
                return true;
            } else if (state.Equals("&Circle"))
            {
                this.selectedShapeIdx = -1;
                circleMode = true;
                points = new List<PointF>();
                createMode = true;
                return true;
            } else if (state.Equals("&Ellipse"))
            {
                this.selectedShapeIdx = -1;
                ellipseMode = true;
                points = new List<PointF>();
                createMode = true;
                return true;
            } else if (state.Equals("&Polygon"))
            {
                this.selectedShapeIdx = -1;
                polygonMode = true;
                points = new List<PointF>();
                createMode = true;
                return true;
            } else if (state.Equals("&Select"))
            {
                this.selectedShapeIdx = -1;
                selectMode = true;
                return true;
            } else if (state.Equals("&Delete"))
            {
                
                if (selectedShapeIdx != -1)
                {
                    this.shapes.RemoveAt(selectedShapeIdx);
                    selectedShapeIdx = -1;
                    selectMode = true;
                    return true;
                }
                
                return false;
            } else if (state.Equals("&Scale"))
            {
                if (selectedShapeIdx != -1)
                {
                    scaleMode = true;
                    return true;
                }
                return false;
            } else if (state.Equals("&Translate"))
            {
                if (selectedShapeIdx != -1)
                {
                    translateMode = true;
                    return true;
                }
                return false;
            } else if (state.Equals("&Rotate"))
            {
                if (selectedShapeIdx != -1)
                {
                    rotateMode = true;
                    return true;
                }
                return false;
            } else if (state.Equals("&Reflect"))
            {
                if (selectedShapeIdx != -1)
                {
                    reflectMode = true;
                    return true;
                }
                return false;
                
                
            }

            
            return false;
        }
    
        
        public bool DrawRubberandingShape(PointF point)
        {
            if (createMode)
            {
                if (triangleMode)
                {
                    rubberbandShape = new Triangle(this.points[0], point);
                    return true;
                } else if (rectangleMode)
                {
                    rubberbandShape = new Quadrilateral(this.points[0], point);
                    return true;
                } else if (squareMode)
                {
                    rubberbandShape = new Square(this.points[0], point);
                    return true;
                } else if (circleMode)
                {
                    rubberbandShape = new Circle(this.points[0], point);
                    return true;
                } else if (ellipseMode)
                {
                    rubberbandShape =  new Ellipse(this.points[0], point);
                    return true;
                } 
                
                


            }
            return false;
        }
    
    }
}