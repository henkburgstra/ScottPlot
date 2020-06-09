using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScottPlot
{
    public enum MarkerShape
    {
        // TODO: capitalize these in ScottPlot 4.1
        none,
        filledCircle,
        filledSquare,
        openCircle,
        openSquare,
        filledDiamond,
        openDiamond,
        asterisk,
        hashTag,
        cross,
        eks,
        verticalBar,
        triUp,
        triDown,
        openTriangle,   // vanaf hier
        arrowheadLeft,  // looks like < with a bigger angle
        arrowheadRight, // looks like > with a bigger angle
        bracketLeft,    // looks like [ but wider
        bracketRight    // looks like ] but wider
    }

    public class MarkerTools
    {
        public static void DrawMarker(Graphics gfx, PointF pixelLocation, MarkerShape shape, float size, Color color)
        {

            Pen pen = new Pen(color);
            Brush brush = new SolidBrush(color);

            float halfSize = size / 2;
            float x1, x2, y1, y2;
            PointF corner1 = new PointF(pixelLocation.X - halfSize, pixelLocation.Y - halfSize);
            PointF corner2 = new PointF(pixelLocation.X + halfSize, pixelLocation.Y + halfSize);
            SizeF bounds = new SizeF(size, size);
            RectangleF rect = new RectangleF(corner1, bounds);

            switch (shape)
            {
                case MarkerShape.filledCircle:
                    gfx.FillEllipse(brush, rect);
                    break;
                case MarkerShape.openCircle:
                    gfx.DrawEllipse(pen, rect);
                    break;
                case MarkerShape.filledSquare:
                    gfx.FillRectangle(brush, rect);
                    break;
                case MarkerShape.openSquare:
                    gfx.DrawRectangle(pen, corner1.X, corner1.Y, size, size);
                    break;
                case MarkerShape.filledDiamond:

                    // Create points that define polygon.
                    PointF point1 = new PointF(pixelLocation.X, pixelLocation.Y + halfSize);
                    PointF point2 = new PointF(pixelLocation.X - halfSize, pixelLocation.Y);
                    PointF point3 = new PointF(pixelLocation.X, pixelLocation.Y - halfSize);
                    PointF point4 = new PointF(pixelLocation.X + halfSize, pixelLocation.Y);

                    PointF[] curvePoints = { point1, point2, point3, point4 };

                    //Draw polygon to screen
                    gfx.FillPolygon(brush, curvePoints);
                    break;
                case MarkerShape.openDiamond:

                    // Create points that define polygon.
                    PointF point5 = new PointF(pixelLocation.X, pixelLocation.Y + halfSize);
                    PointF point6 = new PointF(pixelLocation.X - halfSize, pixelLocation.Y);
                    PointF point7 = new PointF(pixelLocation.X, pixelLocation.Y - halfSize);
                    PointF point8 = new PointF(pixelLocation.X + halfSize, pixelLocation.Y);

                    PointF[] curvePoints2 = { point5, point6, point7, point8 };

                    //Draw polygon to screen
                    gfx.DrawPolygon(pen, curvePoints2);

                    break;
                case MarkerShape.asterisk:
                    Font drawFont = new Font("CourierNew", size * 3);
                    SizeF textSize = Drawing.GDI.MeasureString(gfx, "*", drawFont);
                    PointF asteriskPoint = new PointF(pixelLocation.X - textSize.Width / 2, pixelLocation.Y - textSize.Height / 4);
                    gfx.DrawString("*", drawFont, brush, asteriskPoint);

                    break;
                case MarkerShape.hashTag:
                    Font drawFont2 = new Font("CourierNew", size * 2);
                    SizeF textSize2 = Drawing.GDI.MeasureString(gfx, "#", drawFont2);
                    PointF asteriskPoint2 = new PointF(pixelLocation.X - textSize2.Width / 2, pixelLocation.Y - textSize2.Height / 3);
                    gfx.DrawString("#", drawFont2, brush, asteriskPoint2);

                    break;
                case MarkerShape.cross:
                    Font drawFont3 = new Font("CourierNew", size * 2);
                    SizeF textSize3 = Drawing.GDI.MeasureString(gfx, "+", drawFont3);
                    PointF asteriskPoint3 = new PointF(pixelLocation.X - textSize3.Width / (5 / 2), pixelLocation.Y - textSize3.Height / 2);
                    gfx.DrawString("+", drawFont3, brush, asteriskPoint3);

                    break;
                case MarkerShape.eks:
                    Font drawFont4 = new Font("CourierNew", size * 2);
                    SizeF textSize4 = Drawing.GDI.MeasureString(gfx, "x", drawFont4);
                    PointF asteriskPoint4 = new PointF(pixelLocation.X - textSize4.Width / (5 / 2), pixelLocation.Y - textSize4.Height / 2);
                    gfx.DrawString("x", drawFont4, brush, asteriskPoint4);

                    break;
                case MarkerShape.verticalBar:
                    Font drawFont5 = new Font("CourierNew", size * 2);
                    SizeF textSize5 = Drawing.GDI.MeasureString(gfx, "|", drawFont5);
                    PointF asteriskPoint5 = new PointF(pixelLocation.X - textSize5.Width / (5 / 2), pixelLocation.Y - textSize5.Height / 2);
                    gfx.DrawString("|", drawFont5, brush, asteriskPoint5);

                    break;
                case MarkerShape.triUp:
                    // Create points that define polygon.
                    PointF point9 = new PointF(pixelLocation.X, pixelLocation.Y - size);
                    PointF point10 = new PointF(pixelLocation.X, pixelLocation.Y);
                    PointF point11 = new PointF(pixelLocation.X - size * (float)0.866, pixelLocation.Y + size * (float)0.5);
                    PointF point12 = new PointF(pixelLocation.X, pixelLocation.Y);
                    PointF point13 = new PointF(pixelLocation.X + size * (float)0.866, (pixelLocation.Y + size * (float)0.5));


                    PointF[] curvePoints3 = { point12, point9, point10, point11, point12, point13 };

                    //Draw polygon to screen
                    gfx.DrawPolygon(pen, curvePoints3);

                    break;
                case MarkerShape.triDown:
                    // Create points that define polygon.
                    PointF point14 = new PointF(pixelLocation.X, pixelLocation.Y + size);
                    PointF point15 = new PointF(pixelLocation.X, pixelLocation.Y);
                    PointF point16 = new PointF(pixelLocation.X - size * (float)0.866, pixelLocation.Y - size * (float)0.5);
                    PointF point17 = new PointF(pixelLocation.X, pixelLocation.Y);
                    PointF point18 = new PointF(pixelLocation.X + size * (float)0.866, (pixelLocation.Y - size * (float)0.5));


                    PointF[] curvePoints4 = { point17, point14, point15, point16, point17, point18 };

                    //Draw polygon to screen
                    gfx.DrawPolygon(pen, curvePoints4);

                    break;
                case MarkerShape.openTriangle:
                    gfx.DrawPolygon(pen, new PointF[] {
                        new PointF(pixelLocation.X, pixelLocation.Y - halfSize),
                        new PointF(pixelLocation.X - halfSize, pixelLocation.Y + halfSize),
                        new PointF(pixelLocation.X + halfSize, pixelLocation.Y + halfSize)
                    });
                    break;
                case MarkerShape.arrowheadLeft:
                    x1 = pixelLocation.X + halfSize;
                    x2 = pixelLocation.X - halfSize;
                    y1 = pixelLocation.Y - halfSize;
                    y2 = pixelLocation.Y + halfSize;
                    gfx.DrawLine(pen, new PointF(x1, y1), new PointF(x2, pixelLocation.Y));
                    gfx.DrawLine(pen, new PointF(x2, pixelLocation.Y), new PointF(x1, y2));
                    break;
                case MarkerShape.arrowheadRight:
                    x1 = pixelLocation.X - halfSize;
                    x2 = pixelLocation.X + halfSize;
                    y1 = pixelLocation.Y - halfSize;
                    y2 = pixelLocation.Y + halfSize;
                    gfx.DrawLine(pen, new PointF(x1, y1), new PointF(x2, pixelLocation.Y));
                    gfx.DrawLine(pen, new PointF(x2, pixelLocation.Y), new PointF(x1, y2));
                    break;
                case MarkerShape.bracketLeft:
                    x1 = pixelLocation.X + halfSize;
                    x2 = pixelLocation.X - halfSize;
                    y1 = pixelLocation.Y - halfSize;
                    y2 = pixelLocation.Y + halfSize;
                    gfx.DrawLine(pen, new PointF(x1, y1), new PointF(x2, y1));
                    gfx.DrawLine(pen, new PointF(x2, y1), new PointF(x2, y2));
                    gfx.DrawLine(pen, new PointF(x2, y2), new PointF(x1, y2));
                    break;
                case MarkerShape.bracketRight:
                    x1 = pixelLocation.X - halfSize;
                    x2 = pixelLocation.X + halfSize;
                    y1 = pixelLocation.Y - halfSize;
                    y2 = pixelLocation.Y + halfSize;
                    gfx.DrawLine(pen, new PointF(x1, y1), new PointF(x2, y1));
                    gfx.DrawLine(pen, new PointF(x2, y1), new PointF(x2, y2));
                    gfx.DrawLine(pen, new PointF(x2, y2), new PointF(x1, y2));
                    break;
                default:
                    throw new NotImplementedException($"unsupported marker type: {shape}");
            }
        }
    }
}
