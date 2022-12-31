const toastTrigger = document.getElementById('liveToastBtn')
const toastLiveExample = document.getElementsByClassName('toast')
if (toastTrigger) {
    toastTrigger.addEventListener('click', () => {
        for (const toastElement of toastLiveExample) {
            const toast = new bootstrap.Toast(toastElement)
            toast.show()
        }
    })
}