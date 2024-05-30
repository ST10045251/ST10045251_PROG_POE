using Microsoft.VisualStudio.TestTools.UnitTesting;
using ST10045251_PROG_POE;

namespace RecipeTests
{
    [TestClass]
    public class RecipeTests
    {
        [TestMethod]
        public void TestAddIngredient()
        {
            Recipes recipes = new Recipes("Test Recipe");
            recipes.AddIngredient("Sugar", 1, "tablespoon", 50, "Sweetener");
            Assert.AreEqual("Sugar", recipes.GetIngredients()[0].Name);
        }

        [TestMethod]
        public void TestScaleRecipe()
        {
            Recipes recipes = new Recipes("Test Recipe");
            recipes.AddIngredient("Sugar", 1, "tablespoon", 50, "Sweetener");
            recipes.ScaleRecipe(2);
            Assert.AreEqual(2, recipes.GetIngredients()[0].Quantity);
        }

        [TestMethod]
        public void TestResetQuantities()
        {
            Recipes recipes = new Recipes("Test Recipe");
            recipes.AddIngredient("Sugar", 1, "tablespoon", 50, "Sweetener");
            recipes.ScaleRecipe(2);
            recipes.ResetQuantities();
            Assert.AreEqual(1, recipes.GetIngredients()[0].Quantity);
        }

        [TestMethod]
        public void TestClearRecipe()
        {
            Recipes recipes = new Recipes("Test Recipe");
            recipes.AddIngredient("Sugar", 1, "tablespoon", 50, "Sweetener");
            recipes.ClearRecipe();
            Assert.AreEqual(0, recipes.GetIngredients().Count);
        }
    }
}