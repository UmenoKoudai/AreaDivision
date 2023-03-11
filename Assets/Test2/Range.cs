//生成するオブジェクトの場所を格納
public class Range
{
    //スタート位置とエンド位置
    public Position Start { get; set; }
    public Position End { get; set; }

    public int GetWidthX()
    {
        return End._x - Start._x + 1;
    }

    public int GetWidthY()
    {
        return End._y - Start._y + 1;
    }

    //スタートポジションとエンドポジションを格納
    public Range(Position start,  Position end)
    {
        Start = start;
        End = end;
    }

    //int型変数を4つ指定したらポジション型に直して格納する
    public Range(int startX, int startY, int endX, int endY) : this(new Position(startX, startY), new Position(endX, endY)) { }
    public Range() : this(0, 0, 0, 0) { }

    public override string ToString()
    {
        return string.Format("{0} => {1}", Start, End);
    }
}
