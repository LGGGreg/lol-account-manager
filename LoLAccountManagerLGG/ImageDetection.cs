using System;
using System.Collections.Generic;
using System.Drawing;
namespace LoLAccountManagerLGG
{
    /*Small class used to store a point on the screen and the color that is supposed to be there*/
    public class pointAndColorPair
    {
        public int x;
        public int y;
        public int icolor;
        public Color color;
        public pointAndColorPair(int _x, int _y, int _color)
        {
            x = _x;
            y = _y;
            icolor = _color;
            color = Color.FromArgb((int)(icolor & 0x000000FF),
                    (int)(icolor & 0x0000FF00) >> 8,
                    (int)(icolor & 0x00FF0000) >> 16);
        }

    }
    /*contains a list of points spread out that sorta make a fast image search by finding just them*/
    public class searchableImage
    {
        private List<pointAndColorPair> pointPairs;
        private Point lastFoundPosition = new Point(0, 0);
        private Point loginOffset = new Point(0, 0);
        public Point getLastFoundPosition() { return lastFoundPosition; }
        public searchableImage()
        {
            pointPairs = new List<pointAndColorPair>();
        }
        public searchableImage(List<pointAndColorPair> inpointPairs, Point _loginOffset)
        {
            pointPairs = new List<pointAndColorPair>();
            loginOffset = _loginOffset;
            foreach (pointAndColorPair pp in inpointPairs)
            {
                addPointPair(pp);
            }
        }
        public void addPointPair(pointAndColorPair pp)
        {
            pointPairs.Add(pp);
        }
        public bool foundInScreen(IntPtr screenHandle, Rectangle screenSize)
        {
            IntPtr hBmp;
            IntPtr dc = WindowExternalHelpers.GetDC(screenHandle);
            IntPtr hdcCompatible = WindowExternalHelpers.CreateCompatibleDC(dc);
            hBmp = WindowExternalHelpers.CreateCompatibleBitmap(dc, screenSize.Width, screenSize.Height);

            if (hBmp != IntPtr.Zero)
            {
                IntPtr hOldBmp = (IntPtr)WindowExternalHelpers.SelectObject(hdcCompatible, hBmp);
                WindowExternalHelpers.BitBlt(hdcCompatible, 0, 0, screenSize.Width, screenSize.Height, dc, 0, 0, 13369376);

                WindowExternalHelpers.SelectObject(hdcCompatible, hOldBmp);
                WindowExternalHelpers.DeleteDC(hdcCompatible);
                WindowExternalHelpers.ReleaseDC(screenHandle, dc);

                Bitmap bmp = System.Drawing.Image.FromHbitmap(hBmp);

                WindowExternalHelpers.DeleteObject(hBmp);
                GC.Collect();

                return foundInBitmap(bmp, screenSize);
            }
            return false;
        }
        public bool foundInBitmap(Bitmap bmp, Rectangle screenSize)
        {
            int scanX;
            int scanY;
            scanX = scanY = 0;
            pointAndColorPair theFirstOne = pointPairs[0];
            //see if we find the first point, then find the other ones in relative position
            for (scanX = 0; scanX < screenSize.Width; scanX++)
            {
                for (scanY = 0; scanY < screenSize.Height; scanY++)
                {
                    if (bmp.GetPixel(scanX, scanY) == theFirstOne.color)
                    {
                        bool complete = true;                            
                        //first color detected, check others now
                        foreach (pointAndColorPair pp in pointPairs)
                        {
                            Point relativePosition = new Point(pp.x - theFirstOne.x, pp.y - theFirstOne.y);
                            Color foundColor = bmp.GetPixel(scanX + relativePosition.X, scanY + relativePosition.Y);
                            if (foundColor == pp.color)
                            {
                                //good!
                            }
                            else
                            {
                                //return false;
                                complete = false;
                                break;
                            }
                        }
                        if (complete)
                        {
                            lastFoundPosition = new Point(scanX + loginOffset.X, scanY + loginOffset.Y);
                            return true;
                        }
                        
                    }
                }
            }
            return false;
        }
    }
}
