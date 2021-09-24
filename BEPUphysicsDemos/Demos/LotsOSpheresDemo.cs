using BEPUphysics.Entities.Prefabs;
using BEPUutilities;
using FixMath.NET;
namespace BEPUphysicsDemos.Demos
{
    /// <summary>
    /// A cube of stacked spheres sits and waits to be knocked over.
    /// </summary>
    public class LotsOSpheresDemo : StandardDemo
    {
        /// <summary>
        /// Constructs a new demo.
        /// </summary>
        /// <param name="game">Game owning this demo.</param>
        public LotsOSpheresDemo(DemosGame game)
            : base(game)
        {
            game.Camera.Position = new Vector3(0, 8, 25);
            Space.Add(new Box(new Vector3(0, 0, -110), 240, 1, 240));
            // Space.Add(new Box(new Vector3(0, 0, 0), 240, 1, 240));

            int numColumns = 3;
            int numRows = 3;
            int numHigh = 1000;
            Fix64 xSpacing = 1.09m;
            Fix64 ySpacing = 1.08m;
            Fix64 zSpacing = 1.09m;
            int idx = 0;
            int shapeNum = 1;
            System.Random rng = new System.Random();
            for (int k = 0; k < numHigh; k++)
                for (int j = 0; j < numColumns; j++)
                    for (int i = 0; i < numRows; i++)
                    {
                        if (idx < shapeNum)
                        {
                            int rand = rng.Next(3);
                            Fix64 x = xSpacing * i - (numRows - 1) * xSpacing / 2;
                            Fix64 y = 5m + k * (ySpacing);
                            Fix64 z = 2 + zSpacing * j - (numColumns - 1) * zSpacing / 2;
                            //if (rand == 0)
                            //{
                            //    Space.Add(new Sphere(new Vector3(x, y, z), (Fix64)rng.Next(25, 80) / 100.0m, 1));
                            //}
                            //else if (rand == 1)
                            //{
                            //    Space.Add(new Capsule(new Vector3(x, y, z), (Fix64)rng.Next(25, 80) / 100.0m, (Fix64)rng.Next(25, 80) / 100.0m, 1));
                            //}
                            //else if (rand == 2)
                            //{
                            //    Space.Add(new Box(new Vector3(x, y, z), (Fix64)rng.Next(25, 80) / 100.0m, (Fix64)rng.Next(25, 80) / 100.0m, (Fix64)rng.Next(25, 80) / 100.0m, 1));
                            //}

                            // sphere and box test (correct)
                            // Space.Add(new Box(new Vector3(x, y, z), (Fix64)rng.Next(250, 800) / 100.0m, (Fix64)rng.Next(25, 80) / 100.0m, (Fix64)rng.Next(25, 80) / 100.0m, 1));
                            // Space.Add(new Box(new Vector3(x, y, z), (Fix64)rng.Next(25, 80) / 100.0m, (Fix64)rng.Next(250, 800) / 100.0m, (Fix64)rng.Next(25, 80) / 100.0m, 1));
                            // Space.Add(new Sphere(new Vector3(x, y, z), (Fix64)rng.Next(25, 80) / 100.0m, 1));

                            // capsule test (incorrect)
                            // Space.Add(new Capsule(new Vector3(x, y, z), (Fix64)rng.Next(250, 800) / 100.0m, (Fix64)rng.Next(25, 80) / 100.0m, 1));
                            // Space.Add(new Capsule(new Vector3(x, y, z), (Fix64)rng.Next(25, 80) / 1000.0m, (Fix64)rng.Next(25, 80) / 100.0m, 1));

                            // cylinder test (incorrect)
                            // Space.Add(new Cylinder(new Vector3(x, y, z), (Fix64)rng.Next(250, 800) / 100.0m, (Fix64)rng.Next(25, 80) / 100.0m, 1));
                            Space.Add(new Cylinder(new Vector3(x, y, z), (Fix64)rng.Next(25, 80) / 1000.0m, (Fix64)rng.Next(25, 80) / 100.0m, 1)); // will crash

                            // test for half plates
                            // Space.Add(new Capsule(new Vector3(0, 5, 0), (Fix64)rng.Next(250, 800) / 100.0m, (Fix64)rng.Next(25, 80) / 100.0m, 1));
                            // Space.Add(new Capsule(new Vector3(0, 5, 0), 3.5m, 0.7m, 1.0m));
                            // Space.Add(new Cylinder(new Vector3(0, 5, 0), (Fix64)rng.Next(250, 800) / 100.0m, (Fix64)rng.Next(25, 80) / 100.0m, 1));
                            // Space.Add(new Cylinder(new Vector3(0, 5, 0), 4.5m, 0.8m, 1.0m));
                            // Space.Add(new Cylinder(new Vector3(0, 5, 0), 0.4m, 3.0m, 1.0m));
                            // Space.Add(new Box(new Vector3(0, 5, 0), (Fix64)rng.Next(25, 80) / 100.0m, (Fix64)rng.Next(250, 800) / 100.0m, (Fix64)rng.Next(25, 80) / 100.0m, 1));
                            // Space.Add(new Box(new Vector3(0, 5, 0), 0.3m, 4.5m, 0.4m, 1));
                            idx++;
                        }
                    }
        }
        /// <summary>
        /// Gets the name of the simulation.
        /// </summary>
        public override string Name
        {
            get { return "basic shape rigid collision test"; }
        }
    }
}