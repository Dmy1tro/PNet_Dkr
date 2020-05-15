showPopup = (url, title) => {
    jQuery.ajax({
        type: 'GET',
        url: url,
        success: (res) => {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
        }
    });
};

ajaxPost = (form, updateFunc) => {
    $.ajax({
        type: 'POST',
        url: form.action,
        data: new FormData(form),
        contentType: false,
        processData: false,
        success: (res) => {
            updateFunc();
        },
        error: (err) => {
            console.log(err);
        }
    });
}