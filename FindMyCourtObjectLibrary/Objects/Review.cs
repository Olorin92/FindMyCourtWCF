using FindMyCourtDAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMyCourtObjectLibrary.Objects
{
    public class Review : SaveableObject
    {
        private int _pkid;
        private int _reviewTypeID;
        private int _reviewEntityID;
        private string _reviewComment;
        private byte _reviewRating;
        private string _submittedUserName;

        public int PKID
        {
            get
            {
                return _pkid;
            }
        }

        public int ReviewTypeID
        {
            get
            {
                return _reviewTypeID;
            }
            set
            {
                _reviewTypeID = value;
                OnPropertyChanged("ReviewTypeID");
            }
        }

        public int ReviewEntityID
        {
            get
            {
                return _reviewEntityID;
            }
            set
            {
                _reviewEntityID = value;
                OnPropertyChanged("ReviewEntityID");
            }
        }

        public string ReviewComment
        {
            get
            {
                return _reviewComment;
            }
            set
            {
                _reviewComment = value;
                OnPropertyChanged("ReviewComment");
            }
        }

        public byte ReviewRating
        {
            get
            {
                return _reviewRating;
            }
            set
            {
                _reviewRating = value;
                OnPropertyChanged("ReviewRating");
            }
        }

        public string SubmittedUserName
        {
            get
            {
                return _submittedUserName;
            }
            set
            {
                _submittedUserName = value;
                OnPropertyChanged("SubmittedUserName");
            }
        }

        public Review()
        {
            IsNew = true;
        }

        public static List<Review> GetCourtReviews(int courtID)
        {
            List<Review> courtReviews = new List<Review>();

            try
            {
                using (ReviewDAL dal = new ReviewDAL("environment"))
                {
                    using (SqlDataReader dr = dal.GetCourtReviews(courtID))
                    {
                        while (dr.Read())
                        {
                            Review review = new Review();
                            review.Fetch(dr);

                            courtReviews.Add(review);
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }

            return courtReviews;
        }

        public static List<Review> GetLocationReviews(int locationID)
        {
            List<Review> courtReviews = new List<Review>();

            try
            {
                using (ReviewDAL dal = new ReviewDAL("environment"))
                {
                    using (SqlDataReader dr = dal.GetLocationReviews(locationID))
                    {
                        while (dr.Read())
                        {
                            Review review = new Review();
                            review.Fetch(dr);

                            courtReviews.Add(review);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return courtReviews;
        }

        private void Fetch(SqlDataReader dr)
        {
            _pkid = (int)dr["REVIEW_ID"];
            _reviewTypeID = (int)dr["REVIEW_TYPE_ID"];
            _reviewEntityID = (int)dr["REVIEW_ENTITY_ID"];
            _reviewComment = (string)dr["REVIEW_COMMENT"];
            _reviewRating = (byte)dr["REVIEW_RATING"];
            _submittedUserName = (string)dr["SUBMITTED_USER_NAME"];

            IsNew = false;
            IsDirty = false;
        }


        protected override void Insert()
        {
            using (ReviewDAL dal = new ReviewDAL("environment"))
            {
                _pkid = dal.InsertReview(ReviewTypeID, ReviewEntityID, ReviewComment, ReviewRating, SubmittedUserName);
            }
        }

        protected override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
