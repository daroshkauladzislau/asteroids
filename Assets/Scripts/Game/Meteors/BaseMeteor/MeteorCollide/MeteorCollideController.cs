namespace Game.Meteors.BaseMeteor.MeteorCollide
{
    public abstract class MeteorCollideController
    {
        protected readonly MeteorCollide MeteorCollide;

        protected MeteorCollideController(MeteorCollide meteorCollide)
        {
            MeteorCollide = meteorCollide;
        }
    }
}