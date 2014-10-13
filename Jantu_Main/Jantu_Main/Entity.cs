namespace Jantu
{
    class Entity
    {
        public bool NeedsRedraw
        {
            get { return OnNeedsRedrawQuery(); }
        }

        public Tile Tile
        {
            get { return _tile; }
            set { value.Entity = this; }
        }

        public virtual void Update(double dt)
        {
            return;
        }

        public virtual void Draw()
        {
            return;
        }

        public void OnTileChanged(Tile tile)
        {
            _tile = tile;
        }

        protected virtual bool OnNeedsRedrawQuery()
        {
            return false;
        }

        Tile _tile;
    }
}
