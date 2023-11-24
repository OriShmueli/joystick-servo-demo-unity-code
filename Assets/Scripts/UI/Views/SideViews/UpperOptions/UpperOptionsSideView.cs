using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class UpperOptionsSideView : SideView, IPointerDownHandler
{
    public Button SettingsButton; //opens a window with ui and graphics settings
    public Button ResetCameraButton;
    public Button StopStartProgramButton;
    public Button MoreButton; //phone mode. //exit to menu
    public GameObject MoreButtonsPanel;
    
    public List<SideView_SO> sideViews_SO;
    public bool _isPhoneModeActive = false;

    //public GameObject MoreOptionsPanel;
    public Button HideMoreOptionsButton;
    public Button PhoneModeButton;
    public Button ExitToMenuButton;
    private bool _isMoreOptionsShow = false;

    public Camera CurrentCamera;
    private Vector3 _cameraPosition;
    private Quaternion _cameraRotation;

    [SerializeField]
    private UpperOptionsSideView_SO _upperOptionsSideView_SO;

    public MenuDialogView_SO MenuDialogView_SO;
    public StopProgramDialogView_SO StopProgramDialogView_SO;
    public DialogView_SO dialogView;
    private void OnEnable()
    {

        //Debug.Log("OnEnable Upper side view");
        //called after the enable in parent class.

        foreach (SideView_SO sideView_so in sideViews_SO)
        {
            sideView_so.OnSideViewShow += SideView_so_OnSideViewShow;
        }
    }

    private void Start()
    {
        _upperOptionsSideView_SO = (UpperOptionsSideView_SO)_sideView_SO;
    }
    
    private void OnDisable()
    {
        foreach (SideView_SO sideView_so in sideViews_SO)
        {
            sideView_so.OnSideViewShow -= SideView_so_OnSideViewShow;         
        }
    }

    private void SideView_so_OnSideViewShow()
    {
        PhoneModeButton.GetComponentInChildren<TextMeshProUGUI>().text = "Phone Mode";
        _isPhoneModeActive = false;
    }

    public override void Init()
    {
        //MoreOptionsPanel.SetActive(false); ?
        MoreButtonsPanel.gameObject.GetComponent<CanvasGroup>().alpha = 0f;
        MoreButtonsPanel.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;

        //getting camera starting postions
        _cameraPosition = CurrentCamera.transform.localPosition;
        _cameraRotation = CurrentCamera.transform.localRotation;
       
        //TODO keep working on this
        //SettingsButton.onClick.AddListener();        
        ResetCameraButton.onClick.AddListener(_resetCamera);
        //StopStartProgramButton.onClick.AddListener();
        MoreButton.onClick.AddListener(_showHideMoreOptionsLogic);

        //More options buttons:
        HideMoreOptionsButton.onClick.AddListener(_hideMoreOptionsPanel);

        //Phone mode Button
        PhoneModeButton.onClick.AddListener(_exitEnterPhoneMode);
        _isPhoneModeActive = false;

        //Exit to menu
        ExitToMenuButton.onClick.AddListener(_exitToMenuDialog);

        base.Init();
    }

    public override void Hide()
    {
        _hideMoreOptionsPanel();
        base.Hide();
    }

    private void _exitToMenuDialog()
    {
        dialogView.OnShowDialogView(MenuDialogView_SO);
        //ExitToMenuDialogView_SO.OnShowDialogView("Exiting to menu will stop the program.", "Warning");
    }

    private void _resetCamera()
    {       
        CurrentCamera.transform.position = new Vector3(_cameraPosition.x,
                                                       _cameraPosition.y,
                                                       _cameraPosition.z);
        CurrentCamera.transform.rotation = _cameraRotation;
    }

    private void _showHideMoreOptionsLogic()
    {
        if (_isMoreOptionsShow)
        {
            _hideMoreOptionsPanel();
        }
        else
        {
            _showMoreOptionsPanel();
        }
    }

    private void _showMoreOptionsPanel()
    {
        //Hide main upper buttons panel hide button, when the more options panel is shown
        HideButton.gameObject.GetComponent<CanvasGroup>().alpha = 0f;
        HideButton.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;

        //Showing the more options panel
        MoreButtonsPanel.gameObject.GetComponent<CanvasGroup>().alpha = 1.0f;
        MoreButtonsPanel.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;

        //Set flag
        _isMoreOptionsShow = true;
    }

    private void _hideMoreOptionsPanel()
    {
        //Show main upper buttons panel hide button, when the more options panel is hidden
        HideButton.gameObject.GetComponent<CanvasGroup>().alpha = 1.0f;
        HideButton.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;

        //Hide more options panel
        MoreButtonsPanel.gameObject.GetComponent<CanvasGroup>().alpha = 0f;
        MoreButtonsPanel.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;

        //Set flag
        _isMoreOptionsShow = false;
    }

    private void _exitEnterPhoneMode()
    {
        if (_isPhoneModeActive)
        {
            foreach (SideView_SO sideView in sideViews_SO)
            {
                if (sideView.GetSideViewState() == false)
                {
                    sideView.ShowSideView_Request();
                }
            }

            PhoneModeButton.GetComponentInChildren<TextMeshProUGUI>().text = "Phone Mode";
            _hideMoreOptionsPanel();
            _isPhoneModeActive = false;
        }
        else
        {            
            foreach (SideView_SO sideView in sideViews_SO)
            {
                if (sideView.GetSideViewState() == true)
                {
                    sideView.HideSideView_Request();
                }
            }
            PhoneModeButton.GetComponentInChildren<TextMeshProUGUI>().text = "Exit Phone Mode";
            _isPhoneModeActive = true;
            _hideMoreOptionsPanel();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Need to take care but later...
        if(eventData.pointerCurrentRaycast.gameObject != MoreButtonsPanel || eventData.pointerClick == null)
        {
            _hideMoreOptionsPanel();
        }
    }
}
