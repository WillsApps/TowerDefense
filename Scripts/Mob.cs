using Godot;

namespace TowerDefense.Scripts;

public partial class Mob : CharacterBody3D
{
	[Export] private float Speed = 15.0f;
	[Export] public Godot.Collections.Array<PathNode> PathNodes { get; set; }
	private int _currentNode = 0;

	public void Hit()
	{
		GD.Print("I was hit!");
	}


	public override void _PhysicsProcess(double delta)
	{
		Vector3 next = PathNodes[_currentNode].Position;
		Vector3 direction = (next - Position).Normalized();

		Vector3 velocity = Velocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		// Vector2 inputDir = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector3.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Z = direction.Z * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
		GD.Print(GetSlideCollisionCount());
		for (int i = 0; i < GetSlideCollisionCount(); i++)
		{
			KinematicCollision3D collision = GetSlideCollision(i);
			GD.Print("I collided with ", ((Node)collision.GetCollider()).Name);
			if (((Node)collision.GetCollider()).Name == PathNodes[_currentNode].Name)
			{
				_currentNode += 1;
				if (_currentNode >= PathNodes.Count)
				{
					_currentNode = 0;
				}
			}
		}
	}
}
