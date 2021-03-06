﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using BlockBrawl.Objects;

namespace BlockBrawl.Blocks
{
    class J
    {
        public TetrisObject[,] jMatrix { get; set; }
        //TetrisObject piece;
        Vector2 startPos;

        public Texture2D color { get; set; }
        public float time { get; set; }
        enum iblockState
        {
            one,
            two,
            three,
            four,
        }
        iblockState formation;
        public J(Texture2D color, Vector2 startPos)
        {
            this.color = color;
            this.startPos = startPos;
            jMatrix = new TetrisObject[3, 3];
            //piece = new TetrisObject(Vector2.Zero, color);

            ////Contents of the I, looping through the dubbelarray setting positions and textures
            for (int i = 0; i < jMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < jMatrix.GetLength(1); j++)
                {
                    jMatrix[i, j] = new TetrisObject(Vector2.Zero, color);
                    jMatrix[i, j].PosX = startPos.X + i * color.Width;
                    jMatrix[i, j].PosY = startPos.Y + j * color.Height;
                }
            }

            formation = iblockState.one;//Default formation of the I figure
            UpdateFormation();
        }
        private void UpdateFormation()
        {
            switch (formation)
            {
                case iblockState.one:
                    foreach (TetrisObject item in jMatrix) { item.ChangeState(true); }
                    jMatrix[0, 0].ChangeState(false);
                    jMatrix[0, 1].ChangeState(false);
                    jMatrix[1, 1].ChangeState(false);
                    jMatrix[2, 1].ChangeState(false);
                    break;
                case iblockState.two:
                    foreach (TetrisObject item in jMatrix) { item.ChangeState(true); }
                    jMatrix[1, 0].ChangeState(false);
                    jMatrix[2, 0].ChangeState(false);
                    jMatrix[1, 1].ChangeState(false);
                    jMatrix[1, 2].ChangeState(false);
                    break;
                case iblockState.three:
                    foreach (TetrisObject item in jMatrix) { item.ChangeState(true); }
                    jMatrix[0, 1].ChangeState(false);
                    jMatrix[1, 1].ChangeState(false);
                    jMatrix[2, 1].ChangeState(false);
                    jMatrix[2, 2].ChangeState(false);
                    break;
                case iblockState.four:
                    foreach (TetrisObject item in jMatrix) { item.ChangeState(true); }
                    jMatrix[1, 0].ChangeState(false);
                    jMatrix[1, 1].ChangeState(false);
                    jMatrix[0, 2].ChangeState(false);
                    jMatrix[1, 2].ChangeState(false);
                    break;
            }
        }
        public void Rotate(bool Clockwise)
        {
            if (Clockwise)
            {
                switch (formation)
                {
                    case iblockState.one:
                        formation = iblockState.two;
                        UpdateFormation();
                        break;
                    case iblockState.two:
                        formation = iblockState.three;
                        UpdateFormation();
                        break;
                    case iblockState.three:
                        formation = iblockState.four;
                        UpdateFormation();
                        break;
                    case iblockState.four:
                        formation = iblockState.one;
                        UpdateFormation();
                        break;
                }
            }
            else if (!Clockwise)
            {
                switch (formation)
                {
                    case iblockState.one:
                        formation = iblockState.four;
                        UpdateFormation();
                        break;
                    case iblockState.two:
                        formation = iblockState.one;
                        UpdateFormation();
                        break;
                    case iblockState.three:
                        formation = iblockState.two;
                        UpdateFormation();
                        break;
                    case iblockState.four:
                        formation = iblockState.three;
                        UpdateFormation();
                        break;
                }
            }
        }
        public bool AllowRotation(bool Clockwise, Vector2 maxValues, Vector2 minValues)
        {
            TetrisObject[,] newPosition = new TetrisObject[3, 3];
            for (int i = 0; i < newPosition.GetLength(0); i++)
            {
                for (int j = 0; j < newPosition.GetLength(1); j++)
                {
                    newPosition[i, j] = new TetrisObject(Vector2.Zero, color);
                    newPosition[i, j].PosX = jMatrix[0, 0].PosX + i * color.Width;
                    newPosition[i, j].PosY = jMatrix[0, 0].PosY + j * color.Height;
                }
            }
            if (Clockwise)
            {
                switch (formation)
                {
                    case iblockState.one:
                        foreach (TetrisObject item in newPosition) { item.ChangeState(true); }
                        newPosition[1, 0].ChangeState(false);
                        newPosition[2, 0].ChangeState(false);
                        newPosition[1, 1].ChangeState(false);
                        newPosition[1, 2].ChangeState(false);
                        break;
                    case iblockState.two:
                        foreach (TetrisObject item in newPosition) { item.ChangeState(true); }
                        newPosition[0, 1].ChangeState(false);
                        newPosition[1, 1].ChangeState(false);
                        newPosition[2, 1].ChangeState(false);
                        newPosition[2, 2].ChangeState(false);
                        break;
                    case iblockState.three:
                        foreach (TetrisObject item in newPosition) { item.ChangeState(true); }
                        newPosition[1, 0].ChangeState(false);
                        newPosition[1, 1].ChangeState(false);
                        newPosition[0, 2].ChangeState(false);
                        newPosition[1, 2].ChangeState(false);
                        break;
                    case iblockState.four:
                        foreach (TetrisObject item in newPosition) { item.ChangeState(true); }
                        newPosition[0, 0].ChangeState(false);
                        newPosition[0, 1].ChangeState(false);
                        newPosition[1, 1].ChangeState(false);
                        newPosition[2, 1].ChangeState(false);
                        break;
                }
            }
            else if (!Clockwise)
            {
                switch (formation)
                {
                    case iblockState.one:
                        foreach (TetrisObject item in newPosition) { item.ChangeState(true); }
                        newPosition[1, 0].ChangeState(false);
                        newPosition[1, 1].ChangeState(false);
                        newPosition[0, 2].ChangeState(false);
                        newPosition[1, 2].ChangeState(false);
                        break;
                    case iblockState.two:
                        foreach (TetrisObject item in newPosition) { item.ChangeState(true); }
                        newPosition[0, 0].ChangeState(false);
                        newPosition[0, 1].ChangeState(false);
                        newPosition[1, 1].ChangeState(false);
                        newPosition[2, 1].ChangeState(false);
                        break;
                    case iblockState.three:
                        foreach (TetrisObject item in newPosition) { item.ChangeState(true); }
                        newPosition[1, 0].ChangeState(false);
                        newPosition[2, 0].ChangeState(false);
                        newPosition[1, 1].ChangeState(false);
                        newPosition[1, 2].ChangeState(false);
                        break;
                    case iblockState.four:
                        foreach (TetrisObject item in newPosition) { item.ChangeState(true); }
                        newPosition[0, 1].ChangeState(false);
                        newPosition[1, 1].ChangeState(false);
                        newPosition[2, 1].ChangeState(false);
                        newPosition[2, 2].ChangeState(false);
                        break;
                }
            }
            return minValues.X <= MinValues(newPosition).X && maxValues.X >= MaxValues(newPosition).X && maxValues.Y >= MaxValues(newPosition).Y;
        }
        public void Fall(float lenght)
        {
            foreach (TetrisObject item in jMatrix)
            {
                item.PosY += lenght;
            }
        }
        public void Move(float lenght)
        {
            foreach (TetrisObject item in jMatrix)
            {
                item.PosX += lenght;
            }
        }
        public Vector2 MinValues(TetrisObject[,] tetrisObjects)
        {
            float x = float.MaxValue;
            float y = float.MaxValue;
            for (int i = 0; i < tetrisObjects.GetLength(0); i++)
            {
                for (int j = 0; j < tetrisObjects.GetLength(1); j++)
                {
                    if (tetrisObjects[i, j].PosX < x && tetrisObjects[i, j].alive) { x = tetrisObjects[i, j].PosX; }
                    if (tetrisObjects[i, j].PosY < y && tetrisObjects[i, j].alive) { y = tetrisObjects[i, j].PosY; }
                }
            }
            return new Vector2(x, y);
        }
        public Vector2 MaxValues(TetrisObject[,] tetrisObjects)
        {
            float x = float.MinValue;
            float y = float.MinValue;
            for (int i = 0; i < tetrisObjects.GetLength(0); i++)
            {
                for (int j = 0; j < tetrisObjects.GetLength(1); j++)
                {
                    if (tetrisObjects[i, j].PosX > x && tetrisObjects[i, j].alive) { x = tetrisObjects[i, j].PosX; }
                    if (tetrisObjects[i, j].PosY > y && tetrisObjects[i, j].alive) { y = tetrisObjects[i, j].PosY; }
                }
            }
            return new Vector2(x, y);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (TetrisObject item in jMatrix)
            {
                item.Draw(spriteBatch);
            }
        }
    }
}
