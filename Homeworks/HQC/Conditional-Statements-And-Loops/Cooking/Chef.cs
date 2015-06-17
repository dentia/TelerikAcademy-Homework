namespace Cooking
{
    using System;
    using ToolsAndIngredients;

    public class Chef
    {
        public Bowl Cook()
        {
            Potato potato = this.GetPotato();
            this.Peel(potato);
            this.Cut(potato);

            Carrot carrot = this.GetCarrot();
            this.Peel(carrot);
            this.Cut(carrot);

            Bowl bowl = this.GetBowl();
            bowl.Add(potato);
            bowl.Add(carrot);

            return bowl;
        }

        private Bowl GetBowl()
        {
            return new Bowl();
        }

        private Carrot GetCarrot()
        {
            return new Carrot();
        }

        private Potato GetPotato()
        {
            return new Potato();
        }

        private void Cut(Vegetable vegetable)
        {
            vegetable.Cut();
        }

        private void Peel(Vegetable vegetable)
        {
            vegetable.Peel();
        }
    }
}
