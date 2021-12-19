import React, { useEffect, useState } from 'react';

import News from 'src/Pages/NewsList/Manager';

const NewsManager = () => {
    return (
        <>
            <div className="primaryColor text-title intro-x">
                <News />
            </div>
        </>
    );
};

export default NewsManager;
