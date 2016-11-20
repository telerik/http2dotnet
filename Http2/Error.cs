﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Http2
{
    public enum ErrorType
    {
        ConnectionError,
        StreamError,
    }

    /// <summary>
    /// Error codes that are standardized for HTTP/2
    /// </summary>
    public enum ErrorCode
    {
        NoError = 0x0,
        ProtocolError = 0x1,
        InternalError = 0x2,
        FlowControlError = 0x3,
        SettingsTimeout = 0x4,
        Streamclosed = 0x5,
        FrameSizeError = 0x6,
        RefusedStream = 0x7,
        Cancel = 0x8,
        CompressionError = 0x9,
        ConnectError = 0xa,
        EnhanceYourCalm = 0xb,
        InadequateSecurity = 0xc,
        Http11Required = 0xd,
    }

    public struct Http2Error
    {
        public ErrorType Type;
        public ErrorCode Code;
        public string Message;
    }

    public static class ErrorCodeExtensions
    {
        private static readonly Dictionary<ErrorCode, string>
        Descriptions = new Dictionary<ErrorCode, string>
        {
            {
                ErrorCode.NoError,
                "The associated condition is not a result of an error. " +
                "For example, a GOAWAY might include this code to " +
                "indicate graceful shutdown of a connection"
            },
            {
                ErrorCode.ProtocolError,
                "The endpoint detected an unspecific protocol error. " +
                "This error is for use when a more specific error code is not available"
            },
            {
                ErrorCode.InternalError,
                "The endpoint encountered an unexpected internal error"
            },
            {
                ErrorCode.FlowControlError,
                "The endpoint detected that its peer violated the " +
                "flow-control protocol"
            },
            {
                ErrorCode.SettingsTimeout,
                "The endpoint sent a SETTINGS frame but did not receive " +
                "a response in a timely manner"
            },
            {
                ErrorCode.Streamclosed,
                "The endpoint received a frame after a stream was half-closed"
            },
            {
                ErrorCode.FrameSizeError,
                "The endpoint received a frame with an invalid size"
            },
            {
                ErrorCode.RefusedStream,
                "The endpoint refused the stream prior to performing " +
                "any application processing"
            },
            {
                ErrorCode.Cancel,
                "Used by the endpoint to indicate that the stream is " +
                "no longer needed"
            },
            {
                ErrorCode.CompressionError,
                "The endpoint is unable to maintain the header " +
                "compression context for the connection"
            },
            {
                ErrorCode.ConnectError,
                "The connection established in response to a CONNECT " +
                "request was reset or abnormally closed"
            },
            {
                ErrorCode.EnhanceYourCalm,
                "The endpoint detected that its peer is exhibiting a " +
                "behavior that might be generating excessive load"
            },
            {
                ErrorCode.InadequateSecurity,
                "The underlying transport has properties that do not " +
                "meet minimum security requirements"
            },
            {
                ErrorCode.Http11Required,
                "The endpoint requires that HTTP/1.1 be used instead of " +
                "HTTP/2"
            },
        };

        /// <summary>
        /// Returns a description for an HTTP/2 error code
        /// </summary>
        public static string Description(this ErrorCode code)
        {
            if (Descriptions.TryGetValue(code, out string desc)) return desc;
            return "Unknown error code " + code;
        }
    }
}
