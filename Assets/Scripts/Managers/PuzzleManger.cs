using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManger : Singleton<PuzzleManger>
{ 
        public  Puzzlepiece PuzzlePrefab;
       public Texture2D Texture;
       public Image targetImage;
       
        private Vector2[,] puzzleMap;
        private void Start()
        {
                puzzleMap=new Vector2[3,3];
                SpawnPuzzle(3,  3); 
        }

        /// <summary>
        /// 生产拼图碎片
        /// </summary>
        private void SpawnPuzzle(int x, int y)
        {
                int pieceWidth = Texture.width / x;
                int pieceHeight = Texture.height / y;
                for (int i = 0; i < x; i++)
                {
                        for (int j = 0; j < y; j++)
                        {
                                Texture2D texture = new Texture2D(pieceWidth, pieceHeight);
                                texture.SetPixels(Texture.GetPixels(pieceWidth * i, pieceHeight * j, pieceWidth, pieceHeight));
                                texture.Apply();
                                Puzzlepiece puzzle = Instantiate(PuzzlePrefab, new Vector3(i, j, 0), Quaternion.identity, transform);
                                puzzle.name = $"Puzzle_{i}_{j}";
                                puzzle.GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, pieceWidth, pieceHeight), new Vector2(0.5f, 0.5f));
                                puzzle.GetComponent<RectTransform>().sizeDelta = new Vector2(targetImage.rectTransform.rect.width/x,  targetImage.rectTransform.rect.height/y);
                                RecordRightPos(i, j);
                                puzzle.Init(puzzleMap[i,j]);
                        }
                }
        }

        private void RecordRightPos(int x, int y)
        {
                //TODO: 记录正确的位置
                Vector3 targetPos = targetImage.rectTransform.anchoredPosition;
                targetPos.x -=targetImage.rectTransform.rect.width/3;
                targetPos.y -=targetImage.rectTransform.rect.height/3;
                
                puzzleMap[x,y] = new Vector2(targetPos.x+targetImage.rectTransform.rect.width/3*x,targetPos.y+targetImage.rectTransform.rect.height/3*y);
        }

}
