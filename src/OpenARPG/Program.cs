using Raylib_cs;
using OpenARPG.UI;
using static Raylib_cs.Raylib;

const int screenWidth  = 800;
const int screenHeight = 480;

InitWindow(screenWidth, screenHeight, "OpenARPG");
SetTargetFPS(60);

var playButton = new Button(new Rectangle(300, 200, 200, 50), "Play");

while (!WindowShouldClose())
{
    BeginDrawing();
    ClearBackground(Color.White);

    DrawText("Welcome to OpenARPG", 190, 200, 20, Color.Black);
    playButton.Update();
    playButton.Draw();

    EndDrawing();
}

CloseWindow();