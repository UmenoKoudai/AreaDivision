
//�I�u�W�F�N�g�̍��W���i�[���Ă����N���X
public class Position
{
    //�Q�Ƃł���悤�Ƀv���p�e�B��
    public int _x { get; set; }
    public int _y { get; set; }

    //�ϐ��ɒl�������郁�\�b�h
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
