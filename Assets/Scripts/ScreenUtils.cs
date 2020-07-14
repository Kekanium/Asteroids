using UnityEngine;

/// <summary>
/// Provides screen utilities
/// </summary>
public static class ScreenUtils
{
    #region Fields

    // saved to support resolution changes
    static int _screenWidth;
    static int _screenHeight;

    // cached for efficient boundary checking
    static float _screenLeft;
    static float _screenRight;
    static float _screenTop;
    static float _screenBottom;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the left edge of the screen in world coordinates
    /// </summary>
    /// <value>left edge of the screen</value>
    public static float ScreenLeft
    {
        get
        {
            CheckScreenSizeChanged();
            return _screenLeft;
        }
    }

    /// <summary>
    /// Gets the right edge of the screen in world coordinates
    /// </summary>
    /// <value>right edge of the screen</value>
    public static float ScreenRight
    {
        get
        {
            CheckScreenSizeChanged();
            return _screenRight;
        }
    }

    /// <summary>
    /// Gets the top edge of the screen in world coordinates
    /// </summary>
    /// <value>top edge of the screen</value>
    public static float ScreenTop
    {
        get
        {
            CheckScreenSizeChanged();
            return _screenTop;
        }
    }

    /// <summary>
    /// Gets the bottom edge of the screen in world coordinates
    /// </summary>
    /// <value>bottom edge of the screen</value>
    public static float ScreenBottom
    {
        get 
        {
            CheckScreenSizeChanged();
            return _screenBottom; 
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Initializes the screen utilities
    /// </summary>
    public static void Initialize()
    {
        // save to support resolution changes
        _screenWidth = Screen.width;
        _screenHeight = Screen.height;

        // save screen edges in world coordinates
        float screenZ = -Camera.main.transform.position.z;
        Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenZ);
        Vector3 upperRightCornerScreen = new Vector3(
            _screenWidth, _screenHeight, screenZ);
        Vector3 lowerLeftCornerWorld =
            Camera.main.ScreenToWorldPoint(lowerLeftCornerScreen);
        Vector3 upperRightCornerWorld =
            Camera.main.ScreenToWorldPoint(upperRightCornerScreen);
        _screenLeft = lowerLeftCornerWorld.x;
        _screenRight = upperRightCornerWorld.x;
        _screenTop = upperRightCornerWorld.y;
        _screenBottom = lowerLeftCornerWorld.y;
    }

    /// <summary>
    /// Checks for screen size change
    /// </summary>
    static void CheckScreenSizeChanged()
    {
        if (_screenWidth != Screen.width ||
            _screenHeight != Screen.height)
        {
            Initialize();
        }
    }

    #endregion
}
