# C# Drawing Application

This was a final year university project in the computer graphics module. It is a windows app that allows you to draw simple shapes and transform them.

## Features

- Draw shapes
  - cirlces, squares, triangles, polygons, ellipses and rectangles
- Select drawn shapes
  - delete the selected shapes
  - transform the selected shapes
      - rotate, translate, reflect and scale
- use keyboard shortcuts to switch between modes

## Getting Started

1. **Clone the project**
  
  ```bash
  git clone https://github.com/Hazza101/C--drawing-app.git
  ```
2. **Build and run**
   
  ```bash
  cd repo
  dotnet build
  dotnet run
  ```
   
## Usage

### Demonstration

<video width="600" alt="Demonstration" src="https://github.com/user-attachments/assets/365f5e8c-7cf2-49fe-bde7-10295cdc90c5" type="video/mp4">
</video>

### Functionality

### 7.1 Creating Shapes

| Action | Creating | How to enter |
|--------|----------|--------------|
| Triangle mode | Left click for first point, moving mouse will show shape to be created. Left click again to create triangle. Right click anytime to reset. | Select triangle option in create dropdown<br>or<br><kbd>Ctrl</kbd> + <kbd>2</kbd> |
| Square mode | Same as above | Select square option in create dropdown<br>or<br><kbd>Ctrl</kbd> + <kbd>1</kbd> |
| Ellipse | Same as above | Select ellipse option in create dropdown<br>or<br><kbd>Ctrl</kbd> + <kbd>5</kbd> |
| Circle | Same as above | Select circle option in create dropdown<br>or<br><kbd>Ctrl</kbd> + <kbd>3</kbd> |
| Rectangle | Same as above | Select rectangle option in create dropdown<br>or<br><kbd>Ctrl</kbd> + <kbd>4</kbd> |
| Polygon | Left click to define points of the polygon. When finished right click to create polygon. | Select polygon option in create dropdown<br>or<br><kbd>Ctrl</kbd> + <kbd>6</kbd> |

---

### 7.2 Selecting, deleting and exiting

| Action | Performing action | How to enter |
|--------|------------------|--------------|
| Select mode | Click on the shape you want to select when you are in select mode. To deselect a shape, click anywhere else, create or select again. | Select “select” option in menu strip<br>or<br><kbd>Ctrl</kbd> + <kbd>S</kbd> |
| Delete mode | Once a shape is selected: delete it using delete option. | Select “delete” option in menu strip<br>or<br><kbd>Ctrl</kbd> + <kbd>D</kbd> |
| Exiting | A message box will pop up asking if you are sure you want to exit. Select yes to exit and no to continue. | Select “exit” option in menu strip<br>or<br><kbd>Ctrl</kbd> + <kbd>X</kbd> |

---

### 7.3 Transforming shapes

| Action | Performing action | How to enter |
|--------|------------------|--------------|
| Scale mode | Left click the point you want to scale from. Move mouse left to right (x-axis). Left click again to stop scaling. | Select “scale” option in transform dropdown menu<br>or<br><kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>S</kbd> |
| Reflect mode | Two left clicks to draw the line over which the shape will be reflected. | Select “reflect” option in transform dropdown menu<br>or<br><kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>R</kbd> |
| Translate mode | Left click anywhere and move mouse to move selected shape. Left click again to stop moving. | Select “translate” option in transform dropdown menu<br>or<br><kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>T</kbd> |
| Rotate mode | Left click to start rotating. Move mouse left to right (x-axis). Positive x rotates clockwise, negative anticlockwise. Left click again to stop rotating. | Select “rotate” option in transform dropdown menu<br>or<br><kbd>Ctrl</kbd> + <kbd>R</kbd> |

*Note: Transform functions require a shape to be selected. Otherwise a message box will appear.*

## Project Structure

```text
├── AppManager
|  ├── AppState.cs
|  └── Shortcuts.cs
├── Shapes
|  ├── Circle.cs
|  ├── Ellipse.cs
|  ├── LargePoint.cs
|  ├── PointsShape.cs
|  ├── Polygon.cs
|  ├── Rectangle.cs
|  ├── Shape.cs
|  ├── Square.cs
|  └── Triangle.cs
├── Transformations
|  ├── Line.cs
|  ├── Reflect.cs
|  ├── Rotate.cs
|  ├── Scale.cs
|  └── Translate.cs
├── Utils
|  ├── MathsOps.cs
|  ├── Matrix2D.cs
|  └── MatrixOperations.cs
├── Form1.cs
├── Form1.Designer.cs
├── GrafPack.csproj
├── Grafpack.sln
├── Program.cs
└── README.md
```

## Future Improvements
- Add color for shapes
- Add fill
