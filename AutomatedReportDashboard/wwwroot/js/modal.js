window.modalFunctions = {
    show: function (id) {
        const modal = new bootstrap.Modal(document.getElementById(id));
        modal.show();
    },
    hide: function (id) {
        const modalElement = document.getElementById(id);
        const modalInstance = bootstrap.Modal.getInstance(modalElement);
        if (modalInstance) {
            modalInstance.hide();
        }
    }
};
