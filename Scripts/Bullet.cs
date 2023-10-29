using Godot;

namespace TowerDefense.Scripts;

public partial class Bullet : CharacterBody3D
{
	[Export] private float _speed = 50;
	// Hey

	public void Start(Vector3 position, Vector3 direction)
	{
		Rotation = direction;
		Position = position;
		Velocity = direction.Normalized() * _speed;
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public override void _PhysicsProcess(double delta)
	{
		var collision = MoveAndCollide(Velocity* (float)delta);

		if (collision != null)
		{
			if (collision.GetCollider().HasMethod("Hit"))
			{
				collision.GetCollider().Call("Hit");
			}
		}
	}

	private void OnVisibilityNotifier2DScreenExited()
	{
		// Deletes the bullet when it exits the screen.
		QueueFree();
	}
}
