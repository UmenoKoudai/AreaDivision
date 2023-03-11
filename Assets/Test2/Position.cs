
//オブジェクトの座標を格納しておくクラス
public class Position
{
    //参照できるようにプロパティ化
    public int _x { get; set; }
    public int _y { get; set; }

    //変数に値を代入するメソッド
    public Position(int x, int y)
    {
        this._x = x;
        this._y = y;
    }

    public Position() : this(0, 0) { }

    public override string ToString()
    {
        return string.Format("{0}, {1}", _x, _y);
    }
}
