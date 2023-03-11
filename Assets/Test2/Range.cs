//��������I�u�W�F�N�g�̏ꏊ���i�[
public class Range
{
    //�X�^�[�g�ʒu�ƃG���h�ʒu
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

    //�X�^�[�g�|�W�V�����ƃG���h�|�W�V�������i�[
    public Range(Position start,  Position end)
    {
        Start = start;
        End = end;
    }

    //int�^�ϐ���4�w�肵����|�W�V�����^�ɒ����Ċi�[����
    public Range(int startX, int startY, int endX, int endY) : this(new Position(startX, startY), new Position(endX, endY)) { }
    public Range() : this(0, 0, 0, 0) { }

    public override string ToString()
    {
        return string.Format("{0} => {1}", Start, End);
    }
}
