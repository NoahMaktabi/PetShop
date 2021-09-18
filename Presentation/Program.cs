namespace Presentation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MenuRunner mainMenu = new();
            mainMenu.Start();
        }
    }
}


/*
 * When should you use private instead of public?
 * Private is used to encapsulate the members of the class that should not be exposed to other classes.
 * If we take an example, MenuRunner class in this application. The class has only one public method which is the method that is called in this program class.
 * The Run method is the "interface" of the MenuRunner and only Run should be seen by other classes.
 * MenuRunner has many other methods that are used to make the Run method work as it does. But those methods are only relevant to MenuRunner and should not be seen or used by other classes. That is why we used private instead of public access modifiers.
 *
 *
 *
 * When is it useful to have multiple constructor functions?
 * Multiple constructors or constructor overloading is a powerful technique to create instances of classes with different shapes based on different parameters
 * that are provided via different constructors. For example, we can have a class with 2 constructors.
 * The first one takes no arguments and only prints out a string that says this class is empty.
 * Another constructor to the same class can take 2 arguments name and age and then sets the values of the class members to those arguments.
 * Now instead of just showing a string with no details. We can show a string with details about name and age. This is just a simple way to explain when it is useful.
 *
 * So in conclusion: If we want to have different ways of initializing an object using different number of parameters, then we must do constructor overloading as
 * we do method overloading when we want different definitions of a method based on different parameters.
 *
 * There are a lot of different use cases for this powerful technique. But maybe its out of scope for this homework.
 *
 */
