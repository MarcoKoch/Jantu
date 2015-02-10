namespace Jantu
{
    /// <summary>
    /// Base class for all entities.
    /// </summary>
    /// <remarks>
    /// An entity is an object that can be placed in the game world. All classes
    /// for such objects need to be derived from this one.
    /// </remarks>
    class Entity
    {
        Tile _tile;

        /// <summary>
        /// Returns whether the entity needs to be redrawn on the next frame.
        /// </summary>
        /// <value>
        /// <c>true</c> if needs redraw; otherwise, <c>false</c>.
        /// </value>
        public bool NeedsRedraw
        {
            get { return OnNeedsRedrawQuery(); }
        }

        public bool Blocking
        {
            get { return OnBlockingQuery();  }
        }

        /// <summary>
        /// Gets or sets the tile.
        /// </summary>
        /// <value>
        /// The tile.
        /// </value>
        public Tile Tile
        {
            get { return _tile; }
            set { value.Entity = this; }
        }

        /// <summary>
        /// Updates the entity.
        /// </summary>
        /// <param name='dt'>
        /// Seconds passed since the last call to this method.
        /// </param>
        /// <remarks>
        /// This should be called once per frame.
        /// </remarks>
        public virtual void Update(double dt)
        {
            return;
        }

        /// <summary>
        /// Draws the entity.
        /// </summary>
        public virtual void Draw()
        {
            return;
        }

        /// <summary>
        /// Sets the current tile of the entity.
        /// </summary>
        /// <remarks>
        /// This mothod is for internal use by <cref="Tile.Entity"> only. Do not call this method manually.
        /// </remarks>
        /// <param name="tile"></param>
        public void SetTile(Tile tile)
        {
            OnTileChanged(tile);
        }

        /// <summary>
        /// Call this to trigger a collision with an other entity.
        /// </summary>
        /// <remarks>
        /// This calls <see cref="Jantu.Entity.OnCollision"/> on both, this and other.
        /// </remarks>
        /// <param name="other">The other entitiy with which to collide</param>
        public virtual void CollideWith(Entity other)
        {
            if (OnCollision(other))
                other.OnCollision(this);
        }

        /// <summary>
        /// Called when the tile of the entity changed.
        /// </summary>
        /// <param name='tile'>
        /// New tile.
        /// </param>
        /// <remarks>
        /// This is for internal use by <see cref="Jantu.Tile"/>. Do not call this
        /// method manually.
        /// </remarks>
        protected virtual void OnTileChanged(Tile tile)
        {
            _tile = tile;
        }

        /// <summary>
        /// Called when <see cref="Jantu.Entity.NeedsRedraw"/> is queried.
        /// </summary>
        /// <remarks>
        /// Derived classes may override this to signal when they need to be redrawn.
        /// </remarks>
        protected virtual bool OnNeedsRedrawQuery()
        {
            return false;
        }

        /// <summary>
        /// Called when <see cref="Jantu.Entity.Blocking"/> is queried.
        /// </summary>
        /// <remarks>
        /// Derived classes may override this to block the path of moving entities.
        /// The default implementation returns false.
        /// </remarks>
        protected virtual bool OnBlockingQuery()
        {
            return false;
        }

        /// <summary>
        /// Called if the entity collides with an other one.
        /// </summary>
        /// <param name="other">The other entity with which the collision occured</param>
        /// <returns>
        /// If true is returned, no other <cref="Jantu.Entity.OnCollision()"> handler is called
        /// for this collision.
        /// </returns>
        protected virtual bool OnCollision(Entity other)
        {
            return false;
        }
    }
}
