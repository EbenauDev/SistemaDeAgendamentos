import { useEffect, useState } from 'react';
import './style.less';

function Snackbar({ open, type, children, onClose }) {

    useEffect(() => {
        if (open) {
            setTimeout(() => {
                onClose && onClose();
            }, 5000);
        }

    })

    return <div className={`snackbar ${open && "visible"} ${type}`}>
        <span>{children}</span>
    </div>

}

export default Snackbar;