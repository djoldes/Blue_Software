using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Software
{
    public class FormFunctions
    {
        public static void LoadForm(Form form, Control containerControl)
        {
            if (containerControl.Controls.Count > 0)
            {
                containerControl.Controls.RemoveAt(0);
            }
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            containerControl.Controls.Add(form);
            containerControl.Tag = form;
            form.Show();
        }
    }
}
