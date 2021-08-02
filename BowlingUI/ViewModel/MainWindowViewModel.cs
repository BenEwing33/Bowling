using BowlingScoreLibrary;
using BowlingUI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Newtonsoft.Json;

namespace BowlingUI.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        //Variables needed for UI Logic
        private ScoreCard scoreCard;
        private UserStatistics userStatistics;
        private bool validScoreInput;
        private bool validNameInput;
        private bool isFrameSelected { get; set; }
        private int savedFrame { get; set; }

        //Frame scores and colors
        public string frame1 { get; set; }
        public string frame2 { get; set; }
        public string frame3 { get; set; }
        public string frame4 { get; set; }
        public string frame5 { get; set; }
        public string frame6 { get; set; }
        public string frame7 { get; set; }
        public string frame8 { get; set; }
        public string frame9 { get; set; }
        public string frame10 { get; set; }
        public string frame11 { get; set; }
        public string frame1Color { get; set; }
        public string frame2Color { get; set; }
        public string frame3Color { get; set; }
        public string frame4Color { get; set; }
        public string frame5Color { get; set; }
        public string frame6Color { get; set; }
        public string frame7Color { get; set; }
        public string frame8Color { get; set; }
        public string frame9Color { get; set; }
        public string frame10Color { get; set; }
        public string frame11Color { get; set; }

        //Individual rolls for each frame
        public string f1Roll1 { get; set; }
        public string f1Roll2 { get; set; }
        public string f2Roll1 { get; set; }
        public string f2Roll2 { get; set; }
        public string f3Roll1 { get; set; }
        public string f3Roll2 { get; set; }
        public string f4Roll1 { get; set; }
        public string f4Roll2 { get; set; }
        public string f5Roll1 { get; set; }
        public string f5Roll2 { get; set; }
        public string f6Roll1 { get; set; }
        public string f6Roll2 { get; set; }
        public string f7Roll1 { get; set; }
        public string f7Roll2 { get; set; }
        public string f8Roll1 { get; set; }
        public string f8Roll2 { get; set; }
        public string f9Roll1 { get; set; }
        public string f9Roll2 { get; set; }
        public string f10Roll1 { get; set; }
        public string f10Roll2 { get; set; }
        public string f11Roll1 { get; set; }
        public string f11Roll2 { get; set; }

        //Interactable Objects in the window
        public string messageToUser { get; set; }

        private DateTime _selectedDate;
        public DateTime selectedDate
        {
            get
            {
                return _selectedDate;
            }
            set
            {
                _selectedDate = value;
            }
        }
        
        private List<Record> records;
        public List<Record> Records
        {
            get
            {
                return records;
            }
            set
            {
                records = value;
                OnPropertyChange("Records");
            }
        }
        
        private string _scoreBox;
        public string scoreBox
        {
            get
            {
                return _scoreBox;
            }
            set
            {
                if (validScoreInput)
                {
                    if (btnAdd == "Set Name")
                    {
                        name = value;
                        btnAdd = "Add Score";
                        isFrameSelected = false;
                    }
                    else if (btnAdd == "Set Roll 1")
                    {
                        scoreCard.frameCollection[scoreCard.currentFrame].Roll1 = 0;
                        scoreCard.frameCollection[scoreCard.currentFrame].Roll2 = 0;
                        scoreCard.frameCollection[scoreCard.currentFrame].current_roll = 1;
                        if (ValidateData(value))
                        {
                            UpdateScorecard(Int32.Parse(value));
                            if (Int32.Parse(value) == 10 && scoreCard.currentFrame != 10)
                            {
                                BowlingScorer scorer = new BowlingScorer();
                                for (int i = 1; i <= savedFrame; i++)
                                {
                                    if (i == 1)
                                    {
                                        if (i == scoreCard.currentFrame)
                                        {
                                            scoreCard.frameCollection[scoreCard.currentFrame - 1].Roll2 = 0;
                                            f1Roll2 = "";
                                            OnPropertyChange("f1Roll2");
                                        }
                                        frame1Color = "White";
                                        int frameScore = scoreCard.frameCollection[i - 1].Roll1 + scoreCard.frameCollection[i - 1].Roll2;
                                        if (scoreCard.frameCollection[i - 1].Roll1 == 10)
                                            frame1 = "X";
                                        else if (frameScore == 10)
                                            frame1 = "/";
                                        else
                                            frame1 = scorer.GetScore(scoreCard, i).ToString();
                                        OnPropertyChange("frame1");
                                        OnPropertyChange("frame1Color");
                                    }
                                    else if (i == 2)
                                    {
                                        if (i == scoreCard.currentFrame)
                                        {
                                            scoreCard.frameCollection[scoreCard.currentFrame - 1].Roll2 = 0;
                                            f2Roll2 = "";
                                            OnPropertyChange("f2Roll2");
                                        }
                                        frame2Color = "White";
                                        int frameScore = scoreCard.frameCollection[i - 1].Roll1 + scoreCard.frameCollection[i - 1].Roll2;
                                        if (scoreCard.frameCollection[i - 1].Roll1 == 10)
                                            frame2 = "X";
                                        else if (frameScore == 10)
                                            frame2 = "/";
                                        else
                                            frame2 = scorer.GetScore(scoreCard, i).ToString();
                                        OnPropertyChange("frame2");
                                        OnPropertyChange("frame2Color");
                                    }
                                    else if (i == 3)
                                    {
                                        if (i == scoreCard.currentFrame)
                                        {
                                            scoreCard.frameCollection[scoreCard.currentFrame - 1].Roll2 = 0;
                                            f3Roll2 = "";
                                            OnPropertyChange("f3Roll2");
                                        }
                                        frame3Color = "White";
                                        int frameScore = scoreCard.frameCollection[i - 1].Roll1 + scoreCard.frameCollection[i - 1].Roll2;
                                        if (scoreCard.frameCollection[i - 1].Roll1 == 10)
                                            frame3 = "X";
                                        else if (frameScore == 10)
                                            frame3 = "/";
                                        else
                                            frame3 = scorer.GetScore(scoreCard, i).ToString(); OnPropertyChange("frame3");
                                        OnPropertyChange("frame3Color");
                                    }
                                    else if (i == 4)
                                    {
                                        if (i == scoreCard.currentFrame)
                                        {
                                            scoreCard.frameCollection[scoreCard.currentFrame - 1].Roll2 = 0;
                                            f4Roll2 = "";
                                            OnPropertyChange("f4Roll2");
                                        }
                                        frame4Color = "White";
                                        int frameScore = scoreCard.frameCollection[i - 1].Roll1 + scoreCard.frameCollection[i - 1].Roll2;
                                        if (scoreCard.frameCollection[i - 1].Roll1 == 10)
                                            frame4 = "X";
                                        else if (frameScore == 10)
                                            frame4 = "/";
                                        else
                                            frame4 = scorer.GetScore(scoreCard, i).ToString(); OnPropertyChange("frame4");
                                        OnPropertyChange("frame4Color");
                                    }
                                    else if (i == 5)
                                    {
                                        if (i == scoreCard.currentFrame)
                                        {
                                            scoreCard.frameCollection[scoreCard.currentFrame - 1].Roll2 = 0;
                                            f5Roll2 = "";
                                            OnPropertyChange("f5Roll2");
                                        }
                                        frame5Color = "White";
                                        int frameScore = scoreCard.frameCollection[i - 1].Roll1 + scoreCard.frameCollection[i - 1].Roll2;
                                        if (scoreCard.frameCollection[i - 1].Roll1 == 10)
                                            frame5 = "X";
                                        else if (frameScore == 10)
                                            frame5 = "/";
                                        else
                                            frame5 = scorer.GetScore(scoreCard, i).ToString(); OnPropertyChange("frame5");
                                        OnPropertyChange("frame5Color");
                                    }
                                    else if (i == 6)
                                    {
                                        if (i == scoreCard.currentFrame)
                                        {
                                            scoreCard.frameCollection[scoreCard.currentFrame - 1].Roll2 = 0;
                                            f6Roll2 = "";
                                            OnPropertyChange("f6Roll2");
                                        }
                                        frame6Color = "White";
                                        int frameScore = scoreCard.frameCollection[i - 1].Roll1 + scoreCard.frameCollection[i - 1].Roll2;
                                        if (scoreCard.frameCollection[i - 1].Roll1 == 10)
                                            frame6 = "X";
                                        else if (frameScore == 10)
                                            frame6 = "/";
                                        else
                                            frame6 = scorer.GetScore(scoreCard, i).ToString(); OnPropertyChange("frame6");
                                        OnPropertyChange("frame6Color");
                                    }
                                    else if (i == 7)
                                    {
                                        if (i == scoreCard.currentFrame)
                                        {
                                            scoreCard.frameCollection[scoreCard.currentFrame - 1].Roll2 = 0;
                                            f7Roll2 = "";
                                            OnPropertyChange("f7Roll2");
                                        }
                                        frame7Color = "White";
                                        int frameScore = scoreCard.frameCollection[i - 1].Roll1 + scoreCard.frameCollection[i - 1].Roll2;
                                        if (scoreCard.frameCollection[i - 1].Roll1 == 10)
                                            frame7 = "X";
                                        else if (frameScore == 10)
                                            frame7 = "/";
                                        else
                                            frame7 = scorer.GetScore(scoreCard, i).ToString(); OnPropertyChange("frame7");
                                        OnPropertyChange("frame7Color");
                                    }
                                    else if (i == 8)
                                    {
                                        if (i == scoreCard.currentFrame)
                                        {
                                            scoreCard.frameCollection[scoreCard.currentFrame - 1].Roll2 = 0;
                                            f8Roll2 = "";
                                            OnPropertyChange("f8Roll2");
                                        }
                                        frame8Color = "White";
                                        int frameScore = scoreCard.frameCollection[i - 1].Roll1 + scoreCard.frameCollection[i - 1].Roll2;
                                        if (scoreCard.frameCollection[i - 1].Roll1 == 10)
                                            frame8 = "X";
                                        else if (frameScore == 10)
                                            frame8 = "/";
                                        else
                                            frame8 = scorer.GetScore(scoreCard, i).ToString();
                                        OnPropertyChange("frame8");
                                        OnPropertyChange("frame8Color");
                                    }
                                    else if (i == 9)
                                    {
                                        if (i == scoreCard.currentFrame)
                                        {
                                            scoreCard.frameCollection[scoreCard.currentFrame - 1].Roll2 = 0;
                                            f9Roll2 = "";
                                            OnPropertyChange("f9Roll2");
                                        }
                                        frame9Color = "White";
                                        int frameScore = scoreCard.frameCollection[i - 1].Roll1 + scoreCard.frameCollection[i - 1].Roll2;
                                        if (scoreCard.frameCollection[i - 1].Roll1 == 10)
                                            frame9 = "X";
                                        else if (frameScore == 10)
                                            frame9 = "/";
                                        else
                                            frame9 = scorer.GetScore(scoreCard, i).ToString();
                                        OnPropertyChange("frame9");
                                        OnPropertyChange("frame9Color");
                                    }
                                    else if (i == 10)
                                    {
                                        if (i == scoreCard.currentFrame)
                                        {
                                            scoreCard.frameCollection[scoreCard.currentFrame - 1].Roll2 = 0;
                                            f10Roll2 = "";
                                            OnPropertyChange("f10Roll2");
                                        }
                                        frame10Color = "White";
                                        int frameScore = scoreCard.frameCollection[i - 1].Roll1 + scoreCard.frameCollection[i - 1].Roll2;
                                        if (scoreCard.frameCollection[i - 1].Roll1 == 10)
                                            frame10 = "X";
                                        else if (frameScore == 10)
                                            frame10 = "/";
                                        else
                                            frame10 = scorer.GetScore(scoreCard, i).ToString();
                                        OnPropertyChange("frame10");
                                        OnPropertyChange("frame10Color");
                                    }
                                    else if (i == 11)
                                    {
                                        frame11Color = "White";
                                        frame11 = scorer.GetScore(scoreCard, i).ToString();
                                        OnPropertyChange("frame11");
                                        OnPropertyChange("frame11Color");
                                    }
                                }
                                frame10Color = "White";
                                OnPropertyChange("frame10Color");
                                btnAdd = "Add Score";
                                isFrameSelected = false;
                                scoreCard.currentFrame = savedFrame;
                                btnUndoVisibility = "Visible";
                            }
                            else if (scoreCard.currentFrame == 10 && scoreCard.frameCollection[scoreCard.currentFrame - 1].Roll2 + scoreCard.frameCollection[scoreCard.currentFrame - 1].Roll1 == 10)
                            {
                                btnAdd = "Add Score";
                                isFrameSelected = false;
                                frame11Color = "White";
                                OnPropertyChange("frame11Color");
                                frame10Color = "White";
                                OnPropertyChange("frame10Color");
                                if (f11Roll1 == "")
                                    scoreCard.frameCollection[10].current_roll = 1;
                                else if (f11Roll2 == "")
                                    scoreCard.frameCollection[10].current_roll = 2;
                                btnUndoVisibility = "Visible";
                            }
                            else
                                btnAdd = "Set Roll 2";
                        }
                        else
                        {
                            _scoreBox = "";
                            OnPropertyChange("scoreBox");
                        }
                    }
                    else if (btnAdd == "Set Roll 2")
                    {
                        if (ValidateData(value))
                        {
                            UpdateScorecard(Int32.Parse(value));
                            BowlingScorer scorer = new BowlingScorer();
                            for (int i = 1; i <= savedFrame; i++)
                            {
                                if (i == 1)
                                {
                                    frame1Color = "White";
                                    int frameScore = scoreCard.frameCollection[i - 1].Roll1 + scoreCard.frameCollection[i - 1].Roll2;
                                    if (scoreCard.frameCollection[i - 1].Roll1 == 10)
                                        frame1 = "X";
                                    else if (frameScore == 10)
                                        frame1 = "/";
                                    else
                                        frame1 = scorer.GetScore(scoreCard, i).ToString();
                                    OnPropertyChange("frame1");
                                    OnPropertyChange("frame1Color");
                                }
                                else if (i == 2)
                                {
                                    frame2Color = "White";
                                    int frameScore = scoreCard.frameCollection[i - 1].Roll1 + scoreCard.frameCollection[i - 1].Roll2;
                                    if (scoreCard.frameCollection[i - 1].Roll1 == 10)
                                        frame2 = "X";
                                    else if (frameScore == 10)
                                        frame2 = "/";
                                    else
                                        frame2 = scorer.GetScore(scoreCard, i).ToString();
                                    OnPropertyChange("frame2");
                                    OnPropertyChange("frame2Color");
                                }
                                else if (i == 3)
                                {
                                    frame3Color = "White";
                                    int frameScore = scoreCard.frameCollection[i - 1].Roll1 + scoreCard.frameCollection[i - 1].Roll2;
                                    if (scoreCard.frameCollection[i - 1].Roll1 == 10)
                                        frame3 = "X";
                                    else if (frameScore == 10)
                                        frame3 = "/";
                                    else
                                        frame3 = scorer.GetScore(scoreCard, i).ToString(); OnPropertyChange("frame3");
                                    OnPropertyChange("frame3Color");
                                }
                                else if (i == 4)
                                {
                                    frame4Color = "White";
                                    int frameScore = scoreCard.frameCollection[i - 1].Roll1 + scoreCard.frameCollection[i - 1].Roll2;
                                    if (scoreCard.frameCollection[i - 1].Roll1 == 10)
                                        frame4 = "X";
                                    else if (frameScore == 10)
                                        frame4 = "/";
                                    else
                                        frame4 = scorer.GetScore(scoreCard, i).ToString(); OnPropertyChange("frame4");
                                    OnPropertyChange("frame4Color");
                                }
                                else if (i == 5)
                                {
                                    frame5Color = "White";
                                    int frameScore = scoreCard.frameCollection[i - 1].Roll1 + scoreCard.frameCollection[i - 1].Roll2;
                                    if (scoreCard.frameCollection[i - 1].Roll1 == 10)
                                        frame5 = "X";
                                    else if (frameScore == 10)
                                        frame5 = "/";
                                    else
                                        frame5 = scorer.GetScore(scoreCard, i).ToString(); OnPropertyChange("frame5");
                                    OnPropertyChange("frame5Color");
                                }
                                else if (i == 6)
                                {
                                    frame6Color = "White";
                                    int frameScore = scoreCard.frameCollection[i - 1].Roll1 + scoreCard.frameCollection[i - 1].Roll2;
                                    if (scoreCard.frameCollection[i - 1].Roll1 == 10)
                                        frame6 = "X";
                                    else if (frameScore == 10)
                                        frame6 = "/";
                                    else
                                        frame6 = scorer.GetScore(scoreCard, i).ToString(); OnPropertyChange("frame6");
                                    OnPropertyChange("frame6Color");
                                }
                                else if (i == 7)
                                {
                                    frame7Color = "White";
                                    int frameScore = scoreCard.frameCollection[i - 1].Roll1 + scoreCard.frameCollection[i - 1].Roll2;
                                    if (scoreCard.frameCollection[i - 1].Roll1 == 10)
                                        frame7 = "X";
                                    else if (frameScore == 10)
                                        frame7 = "/";
                                    else
                                        frame7 = scorer.GetScore(scoreCard, i).ToString(); OnPropertyChange("frame7");
                                    OnPropertyChange("frame7Color");
                                }
                                else if (i == 8)
                                {
                                    frame8Color = "White";
                                    int frameScore = scoreCard.frameCollection[i - 1].Roll1 + scoreCard.frameCollection[i - 1].Roll2;
                                    if (scoreCard.frameCollection[i - 1].Roll1 == 10)
                                        frame8 = "X";
                                    else if (frameScore == 10)
                                        frame8 = "/";
                                    else
                                        frame8 = scorer.GetScore(scoreCard, i).ToString();
                                    OnPropertyChange("frame8");
                                    OnPropertyChange("frame8Color");
                                }
                                else if (i == 9)
                                {
                                    frame9Color = "White";
                                    int frameScore = scoreCard.frameCollection[i - 1].Roll1 + scoreCard.frameCollection[i - 1].Roll2;
                                    if (scoreCard.frameCollection[i - 1].Roll1 == 10)
                                        frame9 = "X";
                                    else if (frameScore == 10)
                                        frame9 = "/";
                                    else
                                        frame9 = scorer.GetScore(scoreCard, i).ToString();
                                    OnPropertyChange("frame9");
                                    OnPropertyChange("frame9Color");
                                }
                                else if (i == 10)
                                {
                                    frame10Color = "White";
                                    int frameScore = scoreCard.frameCollection[i - 1].Roll1 + scoreCard.frameCollection[i - 1].Roll2;
                                    if (scoreCard.frameCollection[i - 1].Roll1 == 10)
                                        frame10 = "X";
                                    else if (frameScore == 10)
                                        frame10 = "/";
                                    else
                                        frame10 = scorer.GetScore(scoreCard, i).ToString();
                                    OnPropertyChange("frame10");
                                    OnPropertyChange("frame10Color");
                                }
                                else if (i == 11)
                                {
                                    frame11Color = "White";
                                    frame11 = scorer.GetScore(scoreCard, i).ToString();
                                    if (f11Roll2 == "" && f11Roll1 == "")
                                        frame11 = "";
                                    OnPropertyChange("frame11");
                                    OnPropertyChange("frame11Color");
                                }
                            }
                            btnAdd = "Add Score";
                            isFrameSelected = false;
                            if (scoreCard.currentFrame == 10 && scoreCard.frameCollection[scoreCard.currentFrame - 1].Roll1 + scoreCard.frameCollection[scoreCard.currentFrame - 1].Roll2 != 10)
                            {
                                frame11Color = "White";
                                OnPropertyChange("frame11Color");
                                f11Roll1 = "";
                                f11Roll2 = "";
                                scoreCard.frameCollection[10].current_roll = 1;
                                scoreCard.frameCollection[10].Roll1 = 0;
                                scoreCard.frameCollection[10].Roll2 = 0;
                                OnPropertyChange("f11Roll1");
                                OnPropertyChange("f11Roll2");
                                frame11 = "";
                                OnPropertyChange("frame11");
                                int totalScore = scorer.GetScore(scoreCard);
                                messageToUser = $"Game Over! Final Score: {totalScore}";
                                btnSubmit = "Submit Score";
                                OnPropertyChange("btnSubmit");
                                OnPropertyChange("messageToUser");
                                scoreCard.currentFrame = savedFrame;
                            }
                            else if (scoreCard.currentFrame == 10 && scoreCard.frameCollection[scoreCard.currentFrame - 1].Roll1 == 10)
                            {
                                frame10Color = "White";
                                OnPropertyChange("frame10Color");
                                frame11Color = "White";
                                OnPropertyChange("frame11Color");
                                scoreCard.currentFrame = 10;
                                scoreCard.frameCollection[10].current_roll = 1;
                            }
                            else if (scoreCard.currentFrame == 10 && scoreCard.frameCollection[scoreCard.currentFrame - 1].Roll1 + scoreCard.frameCollection[scoreCard.currentFrame - 1].Roll2 == 10)
                            {
                                frame10Color = "White";
                                OnPropertyChange("frame10Color");
                                frame11Color = "White";
                                OnPropertyChange("frame11Color");
                                scoreCard.frameCollection[10].Roll2 = 0;
                                f11Roll2 = "";
                                OnPropertyChange("f11Roll2");
                                scoreCard.currentFrame = 10;
                                if (f11Roll1 == "" || f11Roll1 == null)
                                    scoreCard.frameCollection[10].current_roll = 1;
                                else
                                {
                                    scoreCard.frameCollection[10].current_roll = 2;
                                    btnSubmitVisibility = "Visible";
                                    btnSubmit = "Submit Score";
                                    OnPropertyChange("btnSubmit");
                                    int totalScore = scorer.GetScore(scoreCard);
                                    messageToUser = $"Game Over! Final Score: {totalScore}";
                                    OnPropertyChange("messageToUser");
                                }
                            }
                            else
                                scoreCard.currentFrame = savedFrame;
                            btnUndoVisibility = "Visible";

                        }
                        else
                        {
                            _scoreBox = "";
                            OnPropertyChange("scoreBox");
                        }
                    }
                    else
                    {
                        messageToUser = "";
                        OnPropertyChange("messageToUser");
                        if (value != null)
                        {
                            if (ValidateData(value))
                            {
                                btnUndoVisibility = "Visible";
                                _scoreBox = value;
                                OnPropertyChange("scoreBox");
                                UpdateScorecard(Int32.Parse(value));
                            }
                            else
                            {
                                _scoreBox = "";
                                OnPropertyChange("scoreBox");
                            }
                        }
                    }
                    validScoreInput = false;
                }
                _scoreBox = value;
            }
        }

        private string _name;
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                scoreCard.playerName = _name;
                OnPropertyChange("name");
            }
        }

        private string _btnAdd;
        public string btnAdd 
        {
            get
            {
                return _btnAdd;
            } 
            set
            {
                _btnAdd = value;
                OnPropertyChange("btnAdd");
            }
        }
        
        public string btnSubmit { get; set; }

        private string _btnUndoVisibility;
        public string btnUndoVisibility
        {
            get
            {
                return _btnUndoVisibility;
            }
            set
            {
                _btnUndoVisibility = value;
                OnPropertyChange("btnUndoVisibility");
            }
        }

        private string _btnReset;
        public string btnReset
        {
            get
            {
                return _btnReset;
            }
            set
            {
                _btnReset = value;
                OnPropertyChange("btnReset");
            }
        }
       
        public string _btnSubmitVisibility;
        public string btnSubmitVisibility
        {
            get
            {
                return _btnSubmitVisibility;
            }
            set
            {
                _btnSubmitVisibility = value;
                OnPropertyChange("btnSubmitVisibility");
            }
        }

        private string _nameSearchBox;
        public string nameSearchBox
        {
            get
            {
                return _nameSearchBox;
            }
            set
            {
                if(validNameInput)
                {
                    Records = userStatistics.GetRecordsForName(value);
                    validNameInput = false;
                    btnResetLeaderboardVisibility = "Visible";
                }
                _nameSearchBox = value;
            }
        }

        private string _btnResetLeaderboardVisibility;
        public string btnResetLeaderboardVisibility
        {
            get
            {
                return _btnResetLeaderboardVisibility;
            }
            set
            {
                _btnResetLeaderboardVisibility = value;
                OnPropertyChange("btnResetLeaderboardVisibility");
            }
        }

        private Record _selectedRecord;
        public Record selectedRecord
        {
            get
            {
                return _selectedRecord;
            }
            set
            {
                if (value != null)
                {
                    scoreCard = new ScoreCard();
                    _selectedRecord = value;
                    Reset();
                    List<Frame> recordFrameCollection = JsonConvert.DeserializeObject<List<Frame>>(_selectedRecord.serializedFrameCollection);
                    name = _selectedRecord.name;
                    OnPropertyChange("name");
                    for (int i = 0; i < recordFrameCollection.Count; i++)
                    {
                        for (int x = 0; x < 2; x++)
                        {
                            if (x == 0)
                                UpdateScorecard(recordFrameCollection[i].Roll1);
                            else if (recordFrameCollection[i].Roll1 != 10 || i == 10)
                                UpdateScorecard(recordFrameCollection[i].Roll2);
                        }
                    }
                    messageToUser = "";
                    OnPropertyChange("messageToUser");
                    btnUndoVisibility = "Collapsed";
                    OnPropertyChange("btnUndoVisibility");
                    btnSubmit = "New Game";
                    OnPropertyChange("btnSubmit");
                    btnSubmitVisibility = "Visible";
                    OnPropertyChange("btnSubmitVisibility");
                    btnAddVisibility = "Collapsed";
                    OnPropertyChange("btnAddVisibility");
                    _selectedRecord = new Record();
                    OnPropertyChange("selectedRecord");
                    scoreBoxVisibility = "Collapsed";
                    OnPropertyChange("scoreBoxVisibility");
                }
            }
        }

        private string _btnAddVisibility;
        public string btnAddVisibility
        {
            get
            {
                return _btnAddVisibility;
            }
            set
            {
                _btnAddVisibility = value;
            }
        }

        private string _scoreBoxVisibility;
        public string scoreBoxVisibility
        {
            get
            {
                return _scoreBoxVisibility;
            }
            set
            {
                _scoreBoxVisibility = value;
            }
        }

        //Constructor
        public MainWindowViewModel() 
        { 
            scoreCard = new ScoreCard();
            userStatistics = new UserStatistics();
            btnAdd = "Set Name";
            name = "Name";
            isFrameSelected = true;
            validScoreInput = false;
            validNameInput = false;
            Records = userStatistics.GetLeaderBoard(10);
            selectedDate = DateTime.Now;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public bool ValidateData(string rollString)
        {
            bool valid;
            try
            {
                int rollValue = Int32.Parse(rollString);
                if (rollValue >= 0 && rollValue <= 10 && scoreCard.currentFrame != 11 && (rollValue + scoreCard.frameCollection[scoreCard.currentFrame].Roll1 <= 10 || scoreCard.currentFrame == 10))
                    valid = true;
                else
                    throw new FormatException();
            }
            catch (Exception)
            {
                valid = false;
                messageToUser = "Invalid Score";
                OnPropertyChange("messageToUser");
            }

            return valid;        
        }

        private void UpdateScorecard(int rollValue)
        {
            messageToUser = "";
            int currentFrame = scoreCard.currentFrame;
            int currentRoll = scoreCard.frameCollection[currentFrame].current_roll;
            BowlingScorer scorer = new BowlingScorer();
            if (currentFrame == 0)
            {
                if (currentRoll == 1)
                {
                    f1Roll1 = rollValue.ToString();
                    scoreCard.RecordNextRoll(rollValue);
                    if (rollValue == 10)
                    {
                        frame1 = "X";
                        OnPropertyChange("frame1");
                    }
                    OnPropertyChange("f1Roll1");
                }
                else
                {
                    f1Roll2 = rollValue.ToString();
                    scoreCard.RecordNextRoll(rollValue);
                    int frameScore = rollValue + Int32.Parse(f1Roll1);
                    if (frameScore == 10)
                        frame1 = " /";
                    else
                        frame1 = scorer.GetScore(scoreCard).ToString();
                    OnPropertyChange("f1Roll2");
                    OnPropertyChange("frame1");
                }
            }
            else if (currentFrame == 1)
            {
                if (currentRoll == 1)
                {
                    f2Roll1 = rollValue.ToString();
                    scoreCard.RecordNextRoll(rollValue);
                    if (rollValue == 10)
                    {
                        frame2 = "X";
                        OnPropertyChange("frame2");
                    }
                    OnPropertyChange("f2Roll1");
                }
                else
                {
                    f2Roll2 = rollValue.ToString();
                    scoreCard.RecordNextRoll(rollValue);
                    int frameScore = rollValue + Int32.Parse(f2Roll1);
                    if (frameScore == 10)
                        frame2 = " /";
                    else
                        frame2 = scorer.GetScore(scoreCard).ToString();
                    OnPropertyChange("f2Roll2");
                    OnPropertyChange("frame2");
                }
            }
            else if (currentFrame == 2)
            {
                if (currentRoll == 1)
                {
                    f3Roll1 = rollValue.ToString();
                    scoreCard.RecordNextRoll(rollValue);
                    if (rollValue == 10)
                    {
                        frame3 = "X";
                        OnPropertyChange("frame3");
                    }
                    OnPropertyChange("f3Roll1");
                }
                else
                {
                    f3Roll2 = rollValue.ToString();
                    scoreCard.RecordNextRoll(rollValue);
                    int frameScore = rollValue + Int32.Parse(f3Roll1);
                    if (frameScore == 10)
                        frame3 = " /";
                    else
                        frame3 = scorer.GetScore(scoreCard).ToString();
                    OnPropertyChange("f3Roll2");
                    OnPropertyChange("frame3");
                }
            }
            else if (currentFrame == 3)
            {
                if (currentRoll == 1)
                {
                    f4Roll1 = rollValue.ToString();
                    scoreCard.RecordNextRoll(rollValue);
                    if (rollValue == 10)
                    {
                        frame4 = "X";
                        OnPropertyChange("frame4");
                    }
                    OnPropertyChange("f4Roll1");
                }
                else
                {
                    f4Roll2 = rollValue.ToString();
                    scoreCard.RecordNextRoll(rollValue);
                    int frameScore = rollValue + Int32.Parse(f4Roll1);
                    if (frameScore == 10)
                        frame4 = " /";
                    else
                        frame4 = scorer.GetScore(scoreCard).ToString();
                    OnPropertyChange("f4Roll2");
                    OnPropertyChange("frame4");
                }
            }
            else if (currentFrame == 4)
            {
                if (currentRoll == 1)
                {
                    f5Roll1 = rollValue.ToString();
                    scoreCard.RecordNextRoll(rollValue);
                    if (rollValue == 10)
                    {
                        frame5 = "X";
                        OnPropertyChange("frame5");
                    }
                    OnPropertyChange("f5roll1");
                }
                else
                {
                    f5Roll2 = rollValue.ToString();
                    scoreCard.RecordNextRoll(rollValue);
                    int frameScore = rollValue + Int32.Parse(f5Roll1);
                    if (frameScore == 10)
                        frame5 = " /";
                    else
                        frame5 = scorer.GetScore(scoreCard).ToString();
                    OnPropertyChange("f5Roll2");
                    OnPropertyChange("frame5");
                }
            }
            else if (currentFrame == 5)
            {
                if (currentRoll == 1)
                {
                    f6Roll1 = rollValue.ToString();
                    scoreCard.RecordNextRoll(rollValue);
                    if (rollValue == 10)
                    {
                        frame6 = "X";
                        OnPropertyChange("frame6");
                    }
                    OnPropertyChange("f6roll1");
                }
                else
                {
                    f6Roll2 = rollValue.ToString();
                    scoreCard.RecordNextRoll(rollValue);
                    int frameScore = rollValue + Int32.Parse(f6Roll1);
                    if (frameScore == 10)
                        frame6 = " /";
                    else
                        frame6 = scorer.GetScore(scoreCard).ToString();
                    OnPropertyChange("f6Roll2");
                    OnPropertyChange("frame6");
                }
            }
            else if (currentFrame == 6)
            {
                if (currentRoll == 1)
                {
                    f7Roll1 = rollValue.ToString();
                    scoreCard.RecordNextRoll(rollValue);
                    if (rollValue == 10)
                    {
                        frame7 = "X";
                        OnPropertyChange("frame7");
                    }
                    OnPropertyChange("f7roll1");
                }
                else
                {
                    f7Roll2 = rollValue.ToString();
                    scoreCard.RecordNextRoll(rollValue);
                    int frameScore = rollValue + Int32.Parse(f7Roll1);
                    if (frameScore == 10)
                        frame7 = " /";
                    else
                        frame7 = scorer.GetScore(scoreCard).ToString();
                    OnPropertyChange("f7Roll2");
                    OnPropertyChange("frame7");
                }
            }
            else if (currentFrame == 7)
            {
                if (currentRoll == 1)
                {
                    f8Roll1 = rollValue.ToString();
                    scoreCard.RecordNextRoll(rollValue);
                    if (rollValue == 10)
                    {
                        frame8 = "X";
                        OnPropertyChange("frame8");
                    }
                    OnPropertyChange("f8roll1");
                }
                else
                {
                    f8Roll2 = rollValue.ToString();
                    scoreCard.RecordNextRoll(rollValue);
                    int frameScore = rollValue + Int32.Parse(f8Roll1);
                    if (frameScore == 10)
                        frame8 = " /";
                    else
                        frame8 = scorer.GetScore(scoreCard).ToString();
                    OnPropertyChange("f8Roll2");
                    OnPropertyChange("frame8");
                }
            }
            else if (currentFrame == 8)
            {
                if (currentRoll == 1)
                {
                    f9Roll1 = rollValue.ToString();
                    scoreCard.RecordNextRoll(rollValue);
                    if (rollValue == 10)
                    {
                        frame9 = "X";
                        OnPropertyChange("frame9");
                    }
                    OnPropertyChange("f9roll1");
                }
                else
                {
                    f9Roll2 = rollValue.ToString();
                    scoreCard.RecordNextRoll(rollValue);
                    int frameScore = rollValue + Int32.Parse(f9Roll1);
                    if (frameScore == 10)
                        frame9 = " /";
                    else
                        frame9 = scorer.GetScore(scoreCard).ToString();
                    OnPropertyChange("f9Roll2");
                    OnPropertyChange("frame9");
                }
            }
            else if (currentFrame == 9)
            {
                if (currentRoll == 1)
                {
                    f10Roll1 = rollValue.ToString();
                    scoreCard.RecordNextRoll(rollValue);
                    if (rollValue == 10)
                    {
                        frame10 = "X";
                        OnPropertyChange("frame10");
                    }
                    OnPropertyChange("f10roll1");
                }
                else
                {
                    f10Roll2 = rollValue.ToString();
                    OnPropertyChange("f10roll2");

                    scoreCard.RecordNextRoll(rollValue);
                    int frameScore = rollValue + Int32.Parse(f10Roll1);
                    if (frameScore == 10)
                    {
                        frame10 = " /";
                        OnPropertyChange("frame10");
                    }

                    else
                    {
                        int totalScore = scorer.GetScore(scoreCard);
                        frame10 = totalScore.ToString();
                        OnPropertyChange("frame10");
                        //scoreBox.IsEnabled = false;
                        //btnAdd.IsEnabled = false;
                        messageToUser = $"Game Over! Final Score: {totalScore}";
                        OnPropertyChange("messageToUser");
                        btnSubmit = "Submit Score";
                        OnPropertyChange("btnSubmit");
                        btnSubmitVisibility = "Visible";
                        OnPropertyChange("btnSubmitVisibility");
                        btnSubmit = "Submit Score";
                        OnPropertyChange("btnSubmit");
                    }
                }
            }
            else if (currentFrame == 10)
            {
                BowlingScoreLibrary.Frame lastFrame = scoreCard.frameCollection[currentFrame - 1];
                if (currentRoll == 1 && scorer.IsStrike(lastFrame))
                {
                    f11Roll1 = rollValue.ToString();
                    scoreCard.RecordNextRoll(rollValue);
                    OnPropertyChange("f11Roll1");
                }
                else if (currentRoll == 1 && scorer.IsSpare(lastFrame))
                {
                    f11Roll1 = rollValue.ToString();
                    scoreCard.RecordNextRoll(rollValue);
                    int totalScore = scorer.GetScore(scoreCard);
                    frame11 = totalScore.ToString();
                    //scoreBox.IsEnabled = false;
                    //btnAdd.IsEnabled = false;
                    messageToUser = $"Game Over! Final Score: {totalScore}";
                    OnPropertyChange("f11Roll1");
                    OnPropertyChange("frame11");
                    OnPropertyChange("messageToUser");
                    btnSubmitVisibility = "Visible";
                    OnPropertyChange("btnSubmitVisibility");
                    btnSubmit = "Submit Score";
                    OnPropertyChange("btnSubmit");
                }
                else if (scorer.IsStrike(lastFrame))
                {
                    f11Roll2 = rollValue.ToString();
                    scoreCard.RecordNextRoll(rollValue);
                    int totalScore = scorer.GetScore(scoreCard);
                    frame11 = totalScore.ToString();
                    //scoreBox.IsEnabled = false;
                    //btnAdd.IsEnabled = false;
                    messageToUser = $"Game Over! Final Score: {totalScore}";
                    OnPropertyChange("f11Roll2");
                    OnPropertyChange("frame11");
                    OnPropertyChange("messageToUser");
                    btnSubmitVisibility = "Visible";
                    OnPropertyChange("btnSubmitVisibility");
                    btnSubmit = "Submit Score";
                    OnPropertyChange("btnSubmit");
                }

            }
            _scoreBox = "";
        }

        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private RelayCommand _enterCommand;
        private RelayCommand _undoClickCommand;
        private RelayCommand _frameClickCommand;
        private RelayCommand _resetClickCommand;
        private RelayCommand _submitClickCommand;
        private RelayCommand _searchEnterCommand;
        private RelayCommand _resetLeaderboard;
        private RelayCommand _searchDateCommand;
        public ICommand SearchEnterCommand
        {
            get
            {
                if (_searchEnterCommand == null)
                {
                    _searchEnterCommand = new RelayCommand(param => SearchEnterPressed(param), param => CanExecute());
                }
                return _searchEnterCommand;
            }
        }

        public ICommand SubmitClickCommand
        {
            get
            {
                if (_submitClickCommand == null)
                {
                    _submitClickCommand = new RelayCommand(param => SubmitClicked(), param => CanExecute());
                }
                return _submitClickCommand;
            }
        }

        public ICommand ResetClickCommand
        {
            get
            {
                if (_resetClickCommand == null)
                {
                    _resetClickCommand = new RelayCommand(param => Reset(), param => CanExecute());
                }
                return _resetClickCommand;
            }
        }

        public ICommand EnterCommand
        {
            get
            {
                if (_enterCommand == null)
                {
                    _enterCommand = new RelayCommand(param => EnterPressed(param), param => CanExecute());
                }
                return _enterCommand;
            }
        }

        public ICommand UndoClickCommand
        {
            get
            {
                if (_undoClickCommand == null)
                {
                    _undoClickCommand = new RelayCommand(param => UndoClicked(), param => CanExecute());
                }
                return _undoClickCommand;
            }
        }

        public ICommand FrameClickCommand
        {
            get
            {
                if (_frameClickCommand == null)
                {
                    _frameClickCommand = new RelayCommand(param => FrameClicked(param), param => CanExecute());
                }
                return _frameClickCommand;
            }
        }

        public ICommand ResetLeaderboardCommand
        {
            get
            {
                if (_resetLeaderboard == null)
                {
                    _resetLeaderboard = new RelayCommand(param => ResetLeaderboard(), param => CanExecute());
                }
                return _resetLeaderboard;
            }
        }

        public ICommand SearchDateCommand
        {
            get
            {
                if (_searchDateCommand == null)
                {
                    _searchDateCommand = new RelayCommand(param => SearchDatePressed(), param => CanExecute());
                }
                return _searchDateCommand;
            }
        }

        public virtual void SearchDatePressed()
        {
            Records = userStatistics.GetRecordsForDate(selectedDate);
            btnResetLeaderboardVisibility = "Visible";
        }

        public virtual void SubmitClicked()
        {
            if (btnSubmit == "Submit Score")
            {
                Record record = new Record();
                BowlingScorer scorer = new BowlingScorer();
                record.name = scoreCard.playerName;
                record.date = scoreCard.gameDate;
                record.score = scorer.GetScore(scoreCard);
                record.serializedFrameCollection = JsonConvert.SerializeObject(scoreCard.frameCollection);
                userStatistics.StoreRecord(record);
                messageToUser = $"Score of {record.score} Recorded";
                OnPropertyChange("messageToUser");
                btnReset = "Visible";
                OnPropertyChange("btnReset");
                btnUndoVisibility = "Visible";
                OnPropertyChange("btnUndoVisibility");
                btnSubmit = "New Game";
                OnPropertyChange("btnSubmit");
                Records = userStatistics.GetLeaderBoard(10);
            }
            else if (btnSubmit == "New Game")
            {
                Reset();
            }
        }

        public virtual void FrameClicked(object o)
        {
            string frameName = o.ToString();
            savedFrame = scoreCard.currentFrame;

            if (!isFrameSelected)
            {
                btnSubmitVisibility = "Collapsed";
                if (frameName == "frame1")
                {
                    if (scoreCard.currentFrame > 0)
                    {
                        scoreCard.currentFrame = 0;
                        scoreCard.frameCollection[scoreCard.currentFrame].current_roll = 1;
                        frame1Color = "LightBlue";
                        OnPropertyChange("frame1Color");
                        btnAdd = "Set Roll 1";
                        f1Roll1 = "";
                        f1Roll2 = "";
                        OnPropertyChange("f1Roll1");
                        OnPropertyChange("f1Roll2");
                        isFrameSelected = true;
                    }
                }
                else if (frameName == "frame2")
                {
                    if (scoreCard.currentFrame > 1)
                    {
                        scoreCard.currentFrame = 1;
                        scoreCard.frameCollection[scoreCard.currentFrame].current_roll = 1;
                        frame2Color = "LightBlue";
                        OnPropertyChange("frame2Color");
                        btnAdd = "Set Roll 1";
                        f2Roll1 = "";
                        f2Roll2 = "";
                        OnPropertyChange("f2Roll1");
                        OnPropertyChange("f2Roll2");
                        isFrameSelected = true;
                    }
                }
                else if (frameName == "frame3")
                {
                    if (scoreCard.currentFrame > 2)
                    {
                        scoreCard.currentFrame = 2;
                        scoreCard.frameCollection[scoreCard.currentFrame].current_roll = 1;
                        frame3Color = "LightBlue";
                        OnPropertyChange("frame3Color");
                        btnAdd = "Set Roll 1";
                        f3Roll1 = "";
                        f3Roll2 = "";
                        OnPropertyChange("f3Roll1");
                        OnPropertyChange("f3Roll2");
                        isFrameSelected = true;
                    }
                }
                else if (frameName == "frame4")
                {
                    if (scoreCard.currentFrame > 3)
                    {
                        scoreCard.currentFrame = 3;
                        scoreCard.frameCollection[scoreCard.currentFrame].current_roll = 1;
                        frame4Color = "LightBlue";
                        OnPropertyChange("frame4Color");
                        btnAdd = "Set Roll 1";
                        f4Roll1 = "";
                        f4Roll2 = "";
                        OnPropertyChange("f4Roll1");
                        OnPropertyChange("f4Roll2");
                        isFrameSelected = true;
                    }
                }
                else if (frameName == "frame5")
                {
                    if (scoreCard.currentFrame > 4)
                    {
                        scoreCard.currentFrame = 4;
                        scoreCard.frameCollection[scoreCard.currentFrame].current_roll = 1;
                        frame5Color = "LightBlue";
                        OnPropertyChange("frame5Color");
                        btnAdd = "Set Roll 1";
                        f5Roll1 = "";
                        f5Roll2 = "";
                        OnPropertyChange("f5Roll1");
                        OnPropertyChange("f5Roll2");
                        isFrameSelected = true;
                    }
                }
                else if (frameName == "frame6")
                {
                    if (scoreCard.currentFrame > 5)
                    {
                        scoreCard.currentFrame = 5;
                        scoreCard.frameCollection[scoreCard.currentFrame].current_roll = 1;
                        frame6Color = "LightBlue";
                        OnPropertyChange("frame6Color");
                        btnAdd = "Set Roll 1";
                        f6Roll1 = "";
                        f6Roll2 = "";
                        OnPropertyChange("f6Roll1");
                        OnPropertyChange("f6Roll2");
                        isFrameSelected = true;
                    }
                }
                else if (frameName == "frame7")
                {
                    if (scoreCard.currentFrame > 6)
                    {
                        scoreCard.currentFrame = 6;
                        scoreCard.frameCollection[scoreCard.currentFrame].current_roll = 1;
                        frame7Color = "LightBlue";
                        OnPropertyChange("frame7Color");
                        btnAdd = "Set Roll 1";
                        f7Roll1 = "";
                        f7Roll2 = "";
                        OnPropertyChange("f7Roll1");
                        OnPropertyChange("f7Roll2");
                        isFrameSelected = true;
                    }
                }
                else if (frameName == "frame8")
                {
                    if (scoreCard.currentFrame > 7)
                    {
                        scoreCard.currentFrame = 7;
                        scoreCard.frameCollection[scoreCard.currentFrame].current_roll = 1;
                        frame8Color = "LightBlue";
                        OnPropertyChange("frame8Color");
                        btnAdd = "Set Roll 1";
                        f8Roll1 = "";
                        f8Roll2 = "";
                        OnPropertyChange("f8Roll1");
                        OnPropertyChange("f8Roll2");
                        isFrameSelected = true;
                    }
                }
                else if (frameName == "frame9")
                {
                    if (scoreCard.currentFrame > 8)
                    {
                        scoreCard.currentFrame = 8;
                        scoreCard.frameCollection[scoreCard.currentFrame].current_roll = 1;
                        frame9Color = "LightBlue";
                        OnPropertyChange("frame9Color");
                        btnAdd = "Set Roll 1";
                        f9Roll1 = "";
                        f9Roll2 = "";
                        OnPropertyChange("f9Roll1");
                        OnPropertyChange("f9Roll2");
                        isFrameSelected = true;
                    }
                }
                else if (frameName == "frame10")
                {
                    if (scoreCard.currentFrame > 9)
                    {
                        scoreCard.currentFrame = 9;
                        scoreCard.frameCollection[scoreCard.currentFrame].current_roll = 1;
                        frame10Color = "LightBlue";
                        OnPropertyChange("frame10Color"); 
                        btnAdd = "Set Roll 1";
                        f10Roll1 = "";
                        f10Roll2 = "";
                        OnPropertyChange("f10Roll1");
                        OnPropertyChange("f10Roll2");
                        isFrameSelected = true;
                    }
                }
                else if (frameName == "frame11")
                {
                    if (scoreCard.currentFrame >= 10)
                    {
                        scoreCard.currentFrame = 10;
                        scoreCard.frameCollection[scoreCard.currentFrame].current_roll = 1;
                        frame11Color = "LightBlue";
                        OnPropertyChange("frame11Color");
                        btnAdd = "Set Roll 1";
                        f11Roll1 = "";
                        f11Roll2 = "";
                        OnPropertyChange("f11Roll1");
                        OnPropertyChange("f11Roll2");
                        isFrameSelected = true;
                    }
                }
                btnUndoVisibility = "Collapsed";
            }
        }

        public virtual void EnterPressed(object o)
        {
            messageToUser = "";
            OnPropertyChange("messageToUser");
            validScoreInput = true;
            scoreBox = o.ToString();
            _scoreBox = "";
            OnPropertyChange("scoreBox");
        }
        public virtual void SearchEnterPressed(object o)
        {
            validNameInput = true;
            nameSearchBox = o.ToString();
            _nameSearchBox = "";
            OnPropertyChange("nameSearchBox");
        }
        public virtual void ResetLeaderboard()
        {
            records = userStatistics.GetLeaderBoard(10);
            OnPropertyChange("records");
            btnResetLeaderboardVisibility = "collapsed";
            OnPropertyChange("btnResetLeaderboardVisibility");
        }

        public virtual void Reset()
        {
            scoreCard = new ScoreCard();
            frame1 = "";
            frame2 = "";
            frame3 = "";
            frame4 = "";
            frame5 = "";
            frame6 = "";
            frame7 = "";
            frame8 = "";
            frame9 = "";
            frame10 = "";
            frame11 = "";
            OnPropertyChange("frame1");
            OnPropertyChange("frame2");
            OnPropertyChange("frame3");
            OnPropertyChange("frame4");
            OnPropertyChange("frame5");
            OnPropertyChange("frame6");
            OnPropertyChange("frame7");
            OnPropertyChange("frame8");
            OnPropertyChange("frame9");
            OnPropertyChange("frame10");
            OnPropertyChange("frame11");
            f1Roll1 = "";
            f1Roll2 = "";
            f2Roll1 = "";
            f2Roll2 = "";
            f3Roll1 = "";
            f3Roll2 = "";
            f4Roll1 = "";
            f4Roll2 = "";
            f5Roll1 = "";
            f5Roll2 = "";
            f6Roll1 = "";
            f6Roll2 = "";
            f7Roll1 = "";
            f7Roll2 = "";
            f8Roll1 = "";
            f8Roll2 = "";
            f9Roll1 = "";
            f9Roll2 = "";
            f10Roll1 = "";
            f10Roll2 = "";
            f11Roll1 = "";
            f11Roll2 = "";
            OnPropertyChange("f1Roll1");
            OnPropertyChange("f1Roll2");
            OnPropertyChange("f2Roll1");
            OnPropertyChange("f2Roll2");
            OnPropertyChange("f3Roll1");
            OnPropertyChange("f3Roll2");
            OnPropertyChange("f4Roll1");
            OnPropertyChange("f4Roll2");
            OnPropertyChange("f5Roll1");
            OnPropertyChange("f5Roll2");
            OnPropertyChange("f6Roll1");
            OnPropertyChange("f6Roll2");
            OnPropertyChange("f7Roll1");
            OnPropertyChange("f7Roll2");
            OnPropertyChange("f8Roll1");
            OnPropertyChange("f8Roll2");
            OnPropertyChange("f9Roll1");
            OnPropertyChange("f9Roll2");
            OnPropertyChange("f10Roll1");
            OnPropertyChange("f10Roll2");
            OnPropertyChange("f11Roll1");
            OnPropertyChange("f11Roll2");
            btnAdd = "Set Name";
            name = "Name";
            isFrameSelected = true;
            OnPropertyChange("btnAdd");
            OnPropertyChange("name");
            btnSubmitVisibility = "Collapsed";
            OnPropertyChange("btnSubmitVisibility");
            btnUndoVisibility = "Collapsed";
            OnPropertyChange("btnUndoVisibility");
            messageToUser = "New Game Created";
            OnPropertyChange("messageToUser");
            btnAddVisibility = "Visible";
            OnPropertyChange("btnAddVisibility");
            scoreBoxVisibility = "Visible";
            OnPropertyChange("scoreBoxVisibility");
        }

        public virtual void UndoClicked()
        {
            btnSubmitVisibility = "Collapsed";
            if (btnUndoVisibility == "Visible")
            {
                messageToUser = "Last Score Removed";
                OnPropertyChange("messageToUser");

                int currentFrame = scoreCard.currentFrame;
                int currentRoll = 0;
                if (currentFrame != 11)
                    currentRoll = scoreCard.frameCollection[currentFrame].current_roll;

                if (currentFrame == 0)
                {
                    if (currentRoll == 2)
                    {
                        btnUndoVisibility = "Collapsed";
                        scoreCard.frameCollection[currentFrame].current_roll = 1;
                        f1Roll1 = "";
                        OnPropertyChange("f1Roll1");
                    }
                }
                else if (currentFrame == 1)
                {
                    if (currentRoll == 1)
                    {

                        currentFrame--;
                        scoreCard.currentFrame -= 1;
                        if (scoreCard.frameCollection[currentFrame].Roll1 != 10)
                        {
                            f1Roll2 = "";
                            OnPropertyChange("f1Roll2");
                            scoreCard.frameCollection[currentFrame].Roll2 = 0;
                            scoreCard.frameCollection[currentFrame].current_roll = 2;
                        }
                        else
                        {
                            f1Roll1 = "";
                            OnPropertyChange("f1Roll1");
                            scoreCard.frameCollection[currentFrame].current_roll = 1;
                        }
                        frame1 = "";
                        OnPropertyChange("frame1");

                    }
                    else
                    {
                        scoreCard.frameCollection[currentFrame].Roll1 = 0;
                        scoreCard.frameCollection[currentFrame].current_roll = 1;
                        f2Roll1 = "";
                        OnPropertyChange("f2Roll1");
                    }
                }
                else if (currentFrame == 2)
                {
                    if (currentRoll == 1)
                    {
                        currentFrame--;
                        scoreCard.currentFrame -= 1;
                        if (scoreCard.frameCollection[currentFrame].Roll1 != 10)
                        {
                            f2Roll2 = "";
                            OnPropertyChange("f2Roll2");
                            scoreCard.frameCollection[currentFrame].Roll2 = 0;
                            scoreCard.frameCollection[currentFrame].current_roll = 2;
                        }
                        else
                        {
                            f2Roll1 = "";
                            OnPropertyChange("f2Roll1");
                            scoreCard.frameCollection[currentFrame].Roll1 = 0;
                            scoreCard.frameCollection[currentFrame].current_roll = 1;
                        }
                        frame2 = "";
                        OnPropertyChange("frame2");
                    }
                    else
                    {
                        scoreCard.frameCollection[currentFrame].Roll1 = 0;
                        scoreCard.frameCollection[currentFrame].current_roll = 1;
                        f3Roll1 = "";
                        OnPropertyChange("f3Roll1");
                    }
                }
                else if (currentFrame == 3)
                {
                    if (currentRoll == 1)
                    {

                        currentFrame--;
                        scoreCard.currentFrame -= 1;
                        if (scoreCard.frameCollection[currentFrame].Roll1 != 10)
                        {
                            f3Roll2 = "";
                            OnPropertyChange("f3Roll2");
                            scoreCard.frameCollection[currentFrame].Roll2 = 0;
                            scoreCard.frameCollection[currentFrame].current_roll = 2;
                        }
                        else
                        {
                            f3Roll1 = "";
                            OnPropertyChange("f3Roll1");
                            scoreCard.frameCollection[currentFrame].Roll1 = 0;
                            scoreCard.frameCollection[currentFrame].current_roll = 1;
                        }
                        frame3 = "";
                        OnPropertyChange("frame3");
                    }
                    else
                    {
                        scoreCard.frameCollection[currentFrame].Roll1 = 0;
                        scoreCard.frameCollection[currentFrame].current_roll = 1;
                        f4Roll1 = "";
                        OnPropertyChange("f4Roll1");
                    }
                }
                else if (currentFrame == 4)
                {
                    if (currentRoll == 1)
                    {
                        currentFrame--;
                        scoreCard.currentFrame -= 1;
                        if (scoreCard.frameCollection[currentFrame].Roll1 != 10)
                        {
                            f4Roll2 = "";
                            OnPropertyChange("f4Roll2");
                            scoreCard.frameCollection[currentFrame].Roll2 = 0;
                            scoreCard.frameCollection[currentFrame].current_roll = 2;
                        }
                        else
                        {
                            f4Roll1 = "";
                            OnPropertyChange("f4Roll1");
                            scoreCard.frameCollection[currentFrame].Roll1 = 0;
                            scoreCard.frameCollection[currentFrame].current_roll = 1;
                        }
                        frame4 = "";
                        OnPropertyChange("frame4");
                    }
                    else
                    {
                        scoreCard.frameCollection[currentFrame].Roll1 = 0;
                        scoreCard.frameCollection[currentFrame].current_roll = 1;
                        f5Roll1 = "";
                        OnPropertyChange("f5Roll1");
                    }
                }
                else if (currentFrame == 5)
                {
                    if (currentRoll == 1)
                    {
                        currentFrame--;
                        scoreCard.currentFrame -= 1;
                        if (scoreCard.frameCollection[currentFrame].Roll1 != 10)
                        {
                            f5Roll2 = "";
                            OnPropertyChange("f5Roll2");
                            scoreCard.frameCollection[currentFrame].Roll2 = 0;
                            scoreCard.frameCollection[currentFrame].current_roll = 2;
                        }
                        else
                        {
                            f5Roll1 = "";
                            OnPropertyChange("f5Roll1");
                            scoreCard.frameCollection[currentFrame].Roll1 = 0;
                            scoreCard.frameCollection[currentFrame].current_roll = 1;
                        }
                        frame5 = "";
                        OnPropertyChange("frame5");
                    }
                    else
                    {
                        scoreCard.frameCollection[currentFrame].Roll1 = 0;
                        scoreCard.frameCollection[currentFrame].current_roll = 1;
                        f6Roll1 = "";
                        OnPropertyChange("f6Roll1");
                    }
                }
                else if (currentFrame == 6)
                {
                    if (currentRoll == 1)
                    {
                        currentFrame--;
                        scoreCard.currentFrame -= 1;
                        if (scoreCard.frameCollection[currentFrame].Roll1 != 10)
                        {
                            f6Roll2 = "";
                            OnPropertyChange("f6Roll2");
                            scoreCard.frameCollection[currentFrame].Roll2 = 0;
                            scoreCard.frameCollection[currentFrame].current_roll = 2;
                        }
                        else
                        {
                            f6Roll1 = "";
                            OnPropertyChange("f6Roll1");
                            scoreCard.frameCollection[currentFrame].Roll1 = 0;
                            scoreCard.frameCollection[currentFrame].current_roll = 1;
                        }
                        frame6 = "";
                        OnPropertyChange("frame6");
                    }
                    else
                    {
                        scoreCard.frameCollection[currentFrame].Roll1 = 0;
                        scoreCard.frameCollection[currentFrame].current_roll = 1;
                        f7Roll1 = "";
                        OnPropertyChange("f7Roll1");
                    }
                }
                else if (currentFrame == 7)
                {
                    if (currentRoll == 1)
                    {
                        currentFrame--;
                        scoreCard.currentFrame -= 1;
                        if (scoreCard.frameCollection[currentFrame].Roll1 != 10)
                        {
                            f7Roll2 = "";
                            OnPropertyChange("f7Roll2");
                            scoreCard.frameCollection[currentFrame].Roll2 = 0;
                            scoreCard.frameCollection[currentFrame].current_roll = 2;
                        }
                        else
                        {
                            f7Roll1 = "";
                            OnPropertyChange("f7Roll1");
                            scoreCard.frameCollection[currentFrame].Roll1 = 0;
                            scoreCard.frameCollection[currentFrame].current_roll = 1;
                        }
                        frame7 = "";
                        OnPropertyChange("frame7");
                    }
                    else
                    {
                        scoreCard.frameCollection[currentFrame].Roll1 = 0;
                        scoreCard.frameCollection[currentFrame].current_roll = 1;
                        f8Roll1 = "";
                        OnPropertyChange("f8Roll1");
                    }
                }
                else if (currentFrame == 8)
                {
                    if (currentRoll == 1)
                    {
                        currentFrame--;
                        scoreCard.currentFrame -= 1;
                        if (scoreCard.frameCollection[currentFrame].Roll1 != 10)
                        {
                            f8Roll2 = "";
                            OnPropertyChange("f8Roll2");
                            scoreCard.frameCollection[currentFrame].Roll2 = 0;
                            scoreCard.frameCollection[currentFrame].current_roll = 2;
                        }
                        else
                        {
                            f8Roll1 = "";
                            OnPropertyChange("f8Roll1");
                            scoreCard.frameCollection[currentFrame].Roll1 = 0;
                            scoreCard.frameCollection[currentFrame].current_roll = 1;
                        }
                        frame8 = "";
                        OnPropertyChange("frame8");
                    }
                    else
                    {
                        scoreCard.frameCollection[currentFrame].Roll1 = 0;
                        scoreCard.frameCollection[currentFrame].current_roll = 1;
                        f9Roll1 = "";
                        OnPropertyChange("f9Roll1");
                    }
                }
                else if (currentFrame == 9)
                {
                    if (currentRoll == 1)
                    {
                        currentFrame--;
                        scoreCard.currentFrame -= 1;
                        if (scoreCard.frameCollection[currentFrame].Roll1 != 10)
                        {
                            f9Roll2 = "";
                            OnPropertyChange("f9Roll2");
                            scoreCard.frameCollection[currentFrame].Roll2 = 0;
                            scoreCard.frameCollection[currentFrame].current_roll = 2;
                        }
                        else
                        {
                            f9Roll1 = "";
                            OnPropertyChange("f9Roll1");
                            scoreCard.frameCollection[currentFrame].Roll1 = 0;
                            scoreCard.frameCollection[currentFrame].current_roll = 1;
                        }
                        frame9 = "";
                        OnPropertyChange("frame9");
                    }
                    else
                    {
                        scoreCard.frameCollection[currentFrame].Roll1 = 0;
                        scoreCard.frameCollection[currentFrame].current_roll = 1;
                        f10Roll1 = "";
                        OnPropertyChange("f10Roll1");
                    }
                }
                else if (currentFrame == 10)
                {
                    if (currentRoll == 1)
                    {
                        currentFrame--;
                        scoreCard.currentFrame -= 1;
                        if (scoreCard.frameCollection[currentFrame].Roll1 != 10)
                        {
                            f10Roll2 = "";
                            OnPropertyChange("f10Roll2");
                            scoreCard.frameCollection[currentFrame].Roll2 = 0;
                            scoreCard.frameCollection[currentFrame].current_roll = 2;
                        }
                        else
                        {
                            f10Roll1 = "";
                            OnPropertyChange("f10Roll1");
                            scoreCard.frameCollection[currentFrame].Roll1 = 0;
                            scoreCard.frameCollection[currentFrame].current_roll = 1;
                        }
                        frame10 = "";
                        OnPropertyChange("frame10");
                    }
                    else
                    {
                        scoreCard.frameCollection[currentFrame].Roll1 = 0;
                        scoreCard.frameCollection[currentFrame].current_roll = 1;
                        f11Roll1 = "";
                        OnPropertyChange("f11Roll1");
                        frame11 = "";
                        OnPropertyChange("frame11");
                    }
                }
                else if (currentFrame == 11)
                {
                    currentFrame--;
                    scoreCard.currentFrame--;
                    scoreCard.frameCollection[currentFrame].Roll2 = 0;
                    scoreCard.frameCollection[currentFrame].current_roll = 2;
                    frame11 = "";
                    OnPropertyChange("frame11");
                    f11Roll2 = "";
                    OnPropertyChange("f11Roll2");
                }
            }
        }

        public virtual bool CanExecute()
        {
            return true;
        }

    }
}
