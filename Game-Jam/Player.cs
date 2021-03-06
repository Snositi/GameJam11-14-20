﻿using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace Game_Jam
{
    class Player : Entity
    {
        private bool isDead = false;
        public Player(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White) : base(x,y,icon,color)
        {
            LocalPosition = new Vector2(x, y);
            _defaultColor = color;
            _icon = icon;
            _velocity = new Vector2();
        }
        public override void Start()
        {
            base.Start();
        }
        public override void Update()
        {
            _oldVelocity = _velocity;
            _oldPosition = LocalPosition;
            int xDirection = -Convert.ToInt32(Game.IsKeyDown(ConsoleKey.A)) + Convert.ToInt32(Game.IsKeyDown(ConsoleKey.D));
            int yDirection = -Convert.ToInt32(Game.IsKeyDown(ConsoleKey.W)) + Convert.ToInt32(Game.IsKeyDown(ConsoleKey.S));
            _velocity = new Vector2(xDirection, yDirection);
            base.Update();
            if (LocalPosition == _oldPosition)
                _velocity = _oldVelocity;
            if (TestCollision())
            {
                if (WasItMe()) { Game.SetGameOver(); }
                if(!WasItMe()) { AddChild(Game.GetCurrentScene().Entities[Game.GetPoints()]);}
            }
        }
        public override void Draw()
        {
            base.Draw();
        }
        public override void End()
        {
            base.End();
        }
    }
}
