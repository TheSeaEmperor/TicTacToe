using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    private int board_width = 3;
    private int board_height = 3;
    private const int BOARD_SIZE = 256;
    private Vector2[] board_pos;

    private void Start()
    {
        Vector2 board_corner = new Vector2(0 - 2 * (BOARD_SIZE / 6), 0 + 2 * (BOARD_SIZE / 6));
        board_pos = new Vector2[board_width * board_height];
        CalcBoardPositions(board_corner);

    }

    private void CalcBoardPositions(Vector2 pos)
    {
        int count = 0;
        float grid_spacing = BOARD_SIZE / 6;

        for (int height = 0; height < board_height; height++)
        {
            for (int width = 0; width < board_width; width++)
            {
                float x_pos = pos.x + (2 * width * grid_spacing);
                float y_pos = pos.y - (2 * height * grid_spacing);

                board_pos[count] = new Vector2(x_pos, y_pos);
                count++;
            }
        }
    }
}
