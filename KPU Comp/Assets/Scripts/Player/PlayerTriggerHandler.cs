using UnityEngine;
using Zenject;

public class PlayerTriggerHandler : MonoBehaviour
{
    private PlayerModel _player;
    private PlayerSettings _playerSettings;
    private PosContainer _posContainer;
    private LevelHandler _levelHandler;

    [Inject]
    private GuiPosNotification _guiPosNotification;

    [Inject]
    public void Construct(
        PlayerModel player,
        PlayerSettings playerSettings,
        PosContainer posContainer,
        LevelHandler levelHandler
        )
    {
        _player = player;
        _playerSettings = playerSettings;
        _posContainer = posContainer;
        _levelHandler = levelHandler;
    }

    /// <summary>
    /// Get The Pos Settings by Key Name
    /// </summary>
    /// <param name="other"></param>
    private PosSettings GetPosSettings(string key)
    {
        _posContainer.Store.TryGetValue(key, out PosSettings posSettings);
        return posSettings;
    }


    /// <summary>
    /// When a player enters a trigger area
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_playerSettings.triggerMask.Contains(other.gameObject.layer)) return;

        if (_levelHandler.CompareState(other.gameObject.tag))
        {
            PosSettings posSettings = GetPosSettings(other.gameObject.tag);

            _player.TriggerItems.AddItem(
                other.gameObject,
                Vector2.Distance(_player.Position, gameObject.transform.position),
                posSettings
            );

            _guiPosNotification.posSettings = posSettings;
            _guiPosNotification.onEnterAnimation();
        }
    }


    /// <summary>
    /// When a player hangs out in a trigger area
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!_playerSettings.triggerMask.Contains(other.gameObject.layer)) return;

        //_player.TriggerItems.UpdateItem(
        //    other.gameObject,
        //    Vector2.Distance(_player.Position, gameObject.transform.position)
        //);
    }


    /// <summary>
    /// When the player leaves the trigger area
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!_playerSettings.triggerMask.Contains(other.gameObject.layer)) return;

        _player.TriggerItems.RemoveItem(other.gameObject);

        //_guiPosNotification.posSettings = null;
        _guiPosNotification.onExitAnimation();
    }

}