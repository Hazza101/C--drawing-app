# C# Drawing application

This was a final year university project in the computer graphics module. It is a windows app that allows you to draw simple shapes and transform them.

## Features

- Draw shapes
  - cirlces, squares, triangles, polygons, ellipses and rectangles
- Select drawn shapes
  - delete the selected shapes
  - transform the selected shapes
      - rotate, translate, reflect and scale
- use keyboard shortcuts to switch between modes

## How to install

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


Find 'how to use' application in grafpack document.

Unfortunatley this is application is not very intuitive but once learned its very quick to do things.

The code for this app is seperated across multiple files for organisation and development purposes, however these files

| Name | Theme | Files |
| :----- | :----------------------- | :----------------------- |
| Shapes | For base shape classes and their derivatives | <kbd>Circle.cs</kbd>, <kbd>Ellipse.cs</kbd>, <kbd>LargePoint.cs</kbd>, <kbd>PointsShape.cs</kbd>, <kbd>Polygon.cs</kbd>, <kbd>Rectangle.cs</kbd>, <kbd>Shape.cs</kbd>, <kbd>Square.cs</kbd>, <kbd>Triangle.cs</kbd> |
| Transformations | Classes that take a shape object or a point and transform it in someway (currently transforms in place) except for line which is a shape | <kbd>Line.cs</kbd>, <kbd>Reflect.cs</kbd>, <kbd>Rotate.cs</kbd>, <kbd>Scale.cs</kbd>, <kbd>Translate.cs</kbd> |
| Utils | Self made matrix classes that are used in the transformations and some math operations | <kbd>MathsOps.cs</kbd>, <kbd>Matrix2D.cs</kbd>, <kbd>MatrixOperations.cs</kbd> |
| AppManager | Manages the flow of the application and interactions between the user and shapes | <kbd>AppState.cs</kbd>, <kbd>Shortcuts.cs</kbd> |
