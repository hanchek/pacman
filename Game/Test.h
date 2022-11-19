#pragma once

#include <SFML/System/Vector2.hpp>

namespace sf
{
    class RenderWindow;
}

namespace Test
{
    void CreateAnimations();

    void CreateBackGround();
    void CreatePlayer();
    void CreateAnimatedPlayer();
    void DestroyPlayer();

    void CreateWalls();
    void CreateWall(const sf::Vector2i& tile);

    void CreateBomb();

    void DrawMissingTexture(sf::RenderWindow& window);
}
