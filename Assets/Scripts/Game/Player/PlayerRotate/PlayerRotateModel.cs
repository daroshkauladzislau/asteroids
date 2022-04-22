namespace Game.Player.PlayerRotate
{
    public class PlayerRotateModel
    {
        public float RotateSpeed { get; }
        public float RotateAngle { get; set; }

        public PlayerRotateModel(float rotateSpeed)
        {
            RotateSpeed = rotateSpeed;
        }
    }
}