using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;

namespace JSOAP {
    /// <summary>
    /// JSON Web Service Adaptor to simplify the process of creating a JSON Web Service
    /// See http://techartisans.blogspot.com/
    /// </summary>

    public class ServiceParameters {
        /// <summary>
        /// JSON Web Service Parameter Definition Object
        /// </summary>
        private string _FieldNames = "";
        private string _Datatype = "";
        private string _Defaultvalue = "";
        private bool _Required = false;

        public ServiceParameters() { }
    } // end class

    public class ServiceDescription {
        /// <summary>
        /// JSON Web Service Parameter Description Object
        /// </summary>
        /// 
        private string _Description = "";
        private string _Location = "";
        public enum HTTPVerbs {
            GET = 0   // Create - Creates (inserts) records
            , POST = 1  // READ - Reads one or more records and one or more fields
            , PUT = 2   // Update - Update all fields in a record.
            , PATCH = 3 // Update - Update some fields in a record
            , DELETE = 4 // Delete - Removes some records
        }

        public ServiceDescription() { }
    } // end class
    
    public class JWSE {

        /// <summary>
        /// JSON Web Service Envelopes (JWSE) for JSOAP (JSON Web Service Object)
        /// </summary>

        public enum ResponseCodes {
            // https://en.wikipedia.org/wiki/List_of_HTTP_status_codes
            Continue = 100
            , SwitchingProtocols = 101
            , Processing = 103
            , OK = 200
            , Created = 201
            , Accepted = 202
            , NonAuthoritativeInformation = 203
            , NoContent = 204
            , ResetContent = 205
            , PartialContent = 206
            , MultiStatus = 207
            , AlreadyReported = 208
            , MovedPermanently = 301
            , TemporaryRedirect = 307
            , BadRequest = 400
            , Unauthorized = 401
            , PaymentRequired = 402
            , Forbidden = 403
            , NotFound = 404
            , MethodNotAllowed = 405
            , NotAcceptable = 406
            , ProxyAuthenticationRequired = 407
            , RequestTimeout = 408
            , Conflict = 409
            , Gone = 410
            , PreconditionFailed = 412
            , PayloadTooLarge = 413
            , URITooLong = 414
            , UnsupportedMediaType = 415
            , RangeNotSatisfiable = 416
            , MisdirectedRequest = 421
            , UnprocessableEntity = 422
            , Locked = 423
            , FailedDependency = 424
            , UpgradeRequired = 426
            , PreconditionRequired = 428
            , TooManyRequests = 429
            , RequestHeaderFieldsTooLarge = 431
            , UnavailableForLegalReasons = 451
            , InternalServerError = 500
            , NotImplemented = 501
            , BadGateway = 502
            , ServiceUnavailable = 503
            , GatewayTimeout = 504
            , VariantAlsoNegotiates = 506
            , InsufficientStorage = 507
            , LoopDetected = 508
            , NotExtended = 510
            , NetworkAuthenticationRequired = 511
            , InvalidToken = 498
            , TokenRequired = 499
            , BandwidthLimitExceeded = 509
            , LoginTimeout = 440
            , NoResponse = 444
            , SSLCertificateError = 495
            , SSLCertificateRequired = 496
            , HTTPRequestSenttoHTTPSPort = 497
            , ClientClosedRequest = 499
        }
        //public Hashtable ResponseCodesDescriptions = new Hashtable();
        private bool _is_built = false;
        protected ResponseCodes _Envelope_code = ResponseCodes.OK;
        private string _Envelope_message = "";
        private string _Envelope_reference = "";
        private string _Envelope_mediatype = "";
        private string _Envelope_service_version = "";
        private string _Envelope_service_uri = "";
        private string _Envelope_jwse_version = "1.0";
        private string _Envelope_jwsdl_uri = "";
        private string _Envelope_sessiontoken = "";
        private DateTime _Envelope_expiresTimestamp;
        private DateTime _Envelope_serverTimestamp;

        // gets and sets
        public ResponseCodes ResponseCode {
            get { return this._Envelope_code; }
            set { this._Envelope_code = value; }
        }
        public string Message {
            get { return this._Envelope_message; }
            set { this._Envelope_message = value; }
        }
        public string Reference {
            get { return this._Envelope_reference; }
            set { this._Envelope_reference = value; }
        }
        public string Mediatype {
            get { return this._Envelope_mediatype; }
            set { this._Envelope_mediatype = value; }
        }
        public string ServiceVersion {
            get { return this._Envelope_service_version; }
            set { this._Envelope_service_version = value; }
        }
        public string ServiceURI {
            get { return this._Envelope_service_uri; }
            set { this._Envelope_service_uri = value; }
        }
        public string ReferenceSection {
            get { return this._Envelope_reference; }
            set { this._Envelope_reference = value; }
        }
        public string SessionToken {
            get { return this._Envelope_sessiontoken; }
            set { this._Envelope_sessiontoken = value; }
        }
        public DateTime ExpirationTimestamp {
            get { return this._Envelope_expiresTimestamp; }
            set { this._Envelope_expiresTimestamp = value; }
        }
        public DateTime ServerTimestamp {
            get { return this._Envelope_serverTimestamp; }
            set { this._Envelope_serverTimestamp = value; }
        }

        // methods
        public JWSE() {
            /// constructor
            if (!_is_built) {
                this._is_built = true;
                //this.BuildResponseCodes();
                this._Envelope_serverTimestamp = DateTime.UtcNow;
            }
        }

        public Hashtable EnvelopeObjectGet(object BodyContent) {
            Hashtable _Result = new Hashtable();
            try {
                Hashtable _Envelope = new Hashtable();
                Hashtable _Head = new Hashtable();

                _Head.Add("service", this._Envelope_service_uri);
                _Head.Add("code", this._Envelope_code);
                _Head.Add("jwse", this._Envelope_jwse_version);

                if (this._Envelope_expiresTimestamp != null
                    && !(
                            String.Compare(
                                "01/01/0001 12:00:00 AM"
                                , this._Envelope_expiresTimestamp.ToString()
                                , true
                             ) == 0
                        )
                ) {
                    _Head.Add("expires", this._Envelope_expiresTimestamp.ToString());
                }
                if (_Envelope_serverTimestamp != null) {
                    _Head.Add("servertime", this._Envelope_serverTimestamp.ToString());
                }
                if (!String.IsNullOrEmpty(this._Envelope_sessiontoken)) {
                    _Head.Add("token", this._Envelope_sessiontoken);
                }
                if (!String.IsNullOrEmpty(this._Envelope_jwsdl_uri)) {
                    _Head.Add("jwsdl", this._Envelope_jwsdl_uri);
                }
                if (!String.IsNullOrEmpty(this._Envelope_service_version)) {
                    _Head.Add("version", this._Envelope_service_version);
                }
                if (!String.IsNullOrEmpty(this._Envelope_message)) {
                    _Head.Add("message", this._Envelope_message);
                }
                if (!String.IsNullOrEmpty(this._Envelope_mediatype)) {
                    _Head.Add("mediatype", this._Envelope_mediatype);
                }
                if (!String.IsNullOrEmpty(this._Envelope_reference)) {
                    _Head.Add("reference", this._Envelope_reference);
                }

                _Envelope.Add("head", _Head);
                _Envelope.Add("body", BodyContent);
                _Result = _Envelope;
            } catch { }
            return _Result;
        }

        public int ResponseCodeGetInt(ResponseCodes ResponseCodeSelected) {
            /// converts int to response code enum
            int _Results = 0;
            try {
                int _current_code = 200;
                if (Enum.IsDefined(typeof(ResponseCodes), ResponseCodeSelected)) {
                    _current_code = (int)ResponseCodeSelected;
                }
                _Results = _current_code;
            } catch { }
            return _Results;
        }

        public ResponseCodes ResponseCodeGetEnum(int ResponseCodeValue) {
            /// converts response code enum to int value
            ResponseCodes _Results = ResponseCodes.OK;
            try {
                _Results = (ResponseCodes)(ResponseCodeValue);
            } catch { }
            return _Results;
        }


        //private void BuildResponseCodes() {
            /// Scaffholding to optionally use later
            //this.ResponseCodesDescriptions.Add();
        //}


    } // end class

    public class JWSDL {
        /// <summary>
        /// JSON Web Services Description Language (JWSDL) for JSOAP (JSON Web Service Object)
        /// </summary>
        /// 
        private List<ServiceDescription> _ServiceDescription = new List<ServiceDescription>();
        private List<ServiceParameters> _ServiceParameters = new List<ServiceParameters>();
        private List<ServiceParameters> _ServiceReturns = new List<ServiceParameters>();

        public JWSDL() {
            /// constructor
        }

        public string JWSDLGet() {
            string _Result = "";

            return _Result;
        }

        public bool ServiceDescriptionAdd() {
            bool _Result = false;

            return _Result;
        }
        public bool ServiceDescriptionRemove() {
            bool _Result = false;

            return _Result;
        }

    } // end class

} // end namespace
