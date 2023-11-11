using System;

//завдання 4

namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            ChristmasTree tree = new ChristmasTree();
            LightsDecorator lightsDecorator = new LightsDecorator();
            OrnamentsDecorator ornamentsDecorator = new OrnamentsDecorator();

            lightsDecorator.SetComponent(tree);
            ornamentsDecorator.SetComponent(lightsDecorator);

            ornamentsDecorator.Operation();

            Console.Read();
        }
    }

    // "ConcreteComponent"
    class ChristmasTree : Component
    {
        public override void Operation()
        {
            Console.WriteLine("Christmas tree is set up");
        }
    }

    // "Decorator"
    abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }

        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    // "ConcreteDecoratorA"
    class LightsDecorator : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("Decorated with lights");
        }
    }

    // "ConcreteDecoratorB"
    class OrnamentsDecorator : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("Added ornaments");
        }
    }

    // "Component"
    abstract class Component
    {
        public abstract void Operation();
    }
}
