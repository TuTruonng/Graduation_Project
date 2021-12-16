import React, { useState, useEffect } from 'react';

import NewsFormContainer from '../NewsForm';

const CreateNewsContainer = () => {
    return (
        <div className="ml-5">
            <div className="primaryColor text-title intro-x">
                Create New News
            </div>

            <div className="row">
                <NewsFormContainer />
            </div>
        </div>
    );
};

export default CreateNewsContainer;
