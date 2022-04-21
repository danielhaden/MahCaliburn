using BasicWindow.Windows;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BasicWindow
{
    public class AppWindowManager : WindowManager
    {
        protected override Window EnsureWindow(object model, object view, bool isDialog)
        {
            Window window = view as BaseWindow;

            if (window == null)
            {
                if (isDialog)
                {
                    window = new BaseDialogWindow
                    {
                        Content = view,
                        SizeToContent = SizeToContent.WidthAndHeight
                    };
                }
                else
                {
                    window = new BaseWindow
                    {
                        Content = view,
                        SizeToContent = SizeToContent.Manual,
                        WindowState = WindowState.Maximized
                    };
                }

                window.SetValue(View.IsGeneratedProperty, true);
            }
            else
            {
                Window owner = this.InferOwnerOf(window);
                if (owner != null && isDialog)
                {
                    window.Owner = owner;
                }
            }

            return window;
        }


    }
}
