import react, { useeffect, usestate } from "react";
import { usehistory, useparams } from "react-router-dom";
import {
    user_profile_storage_key,
    request_access_token_storage_key
} from "../constants/oidc_config";
import { home } from "../constants/pages";
import authservie from "../Services/AuthService";
import request from "../Services/request";

const auth = () => {
    const history = usehistory();
    const { action } = useparams();

    useeffect(() => {
        switch (action) {
            case "login-callback":
                authservie.completeloginasync(window.location.href)
                    .then((values) => {
                        request.setauthentication(values.access_token);
                        localstorage.setitem(user_profile_storage_key, json.stringify(values.profile));
                        localstorage.setitem(request_access_token_storage_key, values.access_token);
                        history.replace(home);
                        window.location.reload();
                    });

                break;

            case "logout-callback":
                authservie.completelogoutasync(window.location.href)
                    .then(() => {
                        localstorage.removeitem(user_profile_storage_key);
                        localstorage.removeitem(request_access_token_storage_key);
                        history.replace(home);
                        window.location.reload();
                    });

                break;

            default:
                break;
        }
    }, [action]);

    return (
        <>
        </>
    );
};

export default Auth;
