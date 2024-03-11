
// Default lambda parameters let calling code skip passing values and lets you add parameters to existing lambda expressions without breaking calling code.
// This simplifies accessing lambda expressions in the same way default parameters in methods simplify calling methods.


var mWithDefault =
    (int a = 0, int b = 0) => a + b;

mWithDefault(); // 0
mWithDefault(5); // 5
mWithDefault(10, 10); // 20












































var fWithDefault =
    (Func<int, int, int> f) => f(1, 2);

fWithDefault((a, b) => { return a + b; });

int M(int a, int b)
{
    return a + b;
}
