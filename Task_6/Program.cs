/*
Choinka!
    *
   ***
  *****
 *******
*********

*/

using System.Text;

char symbol = '*';
char trunkSymbol = '|';

StringBuilder sb = new StringBuilder();

DrawChristmassTree(12, true);

/// <summary>
/// Draw a christmass tree with defined height and optional tree trunk.
/// </summary>
/// <param name="height">The <see cref="System.Int32"/> represents a height of a tree.</param>
/// <param name="treeTrunk">The <see cref="System.Boolean"/> represents a flag used to enable treetrunk draw. </param>
/// <returns>void</returns>
/// <exception cref="System.ArgumentException">
/// <paramref name="height"/> is <c>less than 2</c>.
/// </exception>
void DrawChristmassTree(int height, bool treeTrunk)
{
    if(height < 2)
        throw new ArgumentException("Tree is to small!");

    DrawTree(height);
    if(treeTrunk) DrawTreeTrunk(height);

    Console.WriteLine(sb.ToString());
}

/// <summary>
/// Draw a christmass tree - top part
/// </summary>
/// <param name="height">The <see cref="System.Int32"/> represents a height of a tree.</param>
/// <returns>void</returns>
void DrawTree(int height)
{
    for(int i=1; i <= height; i++)
    {
        var starsCount = (i * 2) - 1;
        var spaceCount = height - starsCount / 2;
        sb.Append(new String(' ', spaceCount));
        sb.Append(new String(symbol, starsCount));
        sb.Append(new String(' ', spaceCount)).Append(System.Environment.NewLine);
    }
}

/// <summary>
/// Draw a christmass tree trunk with fixed height of 2
/// </summary>
/// <returns>void</returns>
void DrawTreeTrunk(int height)
{
    for(int i=1; i < 3; i++)
    {
        var starsCount = 1;
        var spaceCount = height - starsCount / 2;
        sb.Append(new String(' ', spaceCount));
        sb.Append(new String(trunkSymbol, starsCount));
        sb.Append(new String(' ', spaceCount)).Append(System.Environment.NewLine);
    }
}

