using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace WizardsRUs.Models
{
    public class ACSRFThing : IWizardThing
    {
        public string Text { get; set; }

        public bool Checkbox { get; set; }

        public RadioChoice Radio { get; set; }

        public bool ExtraCheckbox { get; set; }

        public ACSRFThing()
        {
            this.Checkbox = false;
            this.ExtraCheckbox = false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("An Anti-CSRF Thing, with ");
            switch (this.Radio)
            {
                case RadioChoice.Radio1:
                    sb.Append("Radiobutton 1 selected, ");
                    break;
                case RadioChoice.Radio2:
                    sb.Append("Radiobutton 2 selected, ");
                    break;
                case RadioChoice.Radio3:
                    sb.Append("Radiobutton 3 selected, ");
                    break;
                default:
                    sb.Append("No Radiobutton selected, ");
                    break;
            }

            if (this.Checkbox)
            {
                sb.Append("Checkbox checked, ");
            }
            else
            {
                sb.Append("Checkbox unchecked, ");
            }

            sb.Append("and \"" + this.Text + "\" entered in the textbox.");

            if (this.ExtraCheckbox)
            {
                sb.Append(" (The Extra Checkbox was also checked)");
            }
            sb.Append(".");

            return sb.ToString();
        }
    }
}