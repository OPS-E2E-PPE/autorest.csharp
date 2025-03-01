// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { InputApiKeyAuth } from "./InputApiKeyAuth.js";
import { InputOAuth2Auth } from "./InputOAuth2Auth.js";

export interface InputAuth {
    ApiKey?: InputApiKeyAuth;
    OAuth2?: InputOAuth2Auth;
}
