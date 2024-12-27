// Update displayed file name when a file is selected
function updateFileName(event) {
    const fileName = event.target.files[0]?.name || 'No file selected';
    document.getElementById('fileName').textContent = fileName;
}

// Preview Image Before Upload
function previewImage(event) {
    const preview = document.getElementById('imagePreview');
    const file = event.target.files[0];

    if (file) {
        const reader = new FileReader();
        reader.onload = function (e) {
            preview.src = e.target.result;
            preview.style.display = 'block';
        };
        reader.readAsDataURL(file);
    } else {
        preview.src = "#";
        preview.style.display = 'none';
    }
}

//function showDeleteModal(id) {
//    const deleteUrl = `@Url.Action("Delete")/${id}`;
//    document.getElementById('confirmDeleteButton').setAttribute('href', deleteUrl);
//    $('#deleteConfirmationModal').modal('show');
//}

function showDeleteModal(id) {
    const deleteUrl = `/Admin/${controllerName}/Delete/${id}`; // Use the controller name dynamically
    document.getElementById('confirmDeleteButton').setAttribute('href', deleteUrl);
    $('#deleteConfirmationModal').modal('show');
}