namespace SumNumbers
{
    using System;

    public partial class SumNumbers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void OnSubmitButtonClick(object sender, EventArgs e)
        {
            this.sumResult.Text = (int.Parse(this.sumA.Value) + int.Parse(this.sumB.Value)).ToString();
        }
    }
}