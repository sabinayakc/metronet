
class Validator {
    form: HTMLFormElement;
    reset: HTMLButtonElement;
    fields = ["Name", "FunFact"];
    formHidden: boolean;
    formSubmission: HTMLElement;

    constructor() {
        this.form = document.getElementById('introduction-form') as HTMLFormElement;
        this.formSubmission = document.getElementById('form-submission') as HTMLElement;
        this.formHidden = false;
    }

    initialize() {
        this.validate();
    }

    validate = () => {
        this.form.addEventListener('submit', e => {
            e.preventDefault();
            const invalids = [];
            const valids = [];
            Array.from(this.form.elements).forEach(field => {

                var source = field as HTMLFormElement;
                if (this.fields.indexOf(source.name) > -1) {

                    var result = source.checkValidity();
                    if (!result) {
                        invalids.push(source.name);
                    } else {
                        valids.push({name:source.name, value:source.value})
                    } 
                }
            });
            if (invalids.length > 0) {
                alert(`Form is not valid. Fields : ${invalids.join(", ")}`);
            } 
            if (this.form.checkValidity()) {
                this.toggleFormContainer();
                var html = "";
                valids.forEach(v => {
                    console.log(v)
                    html = html.concat(this.buildContent(v));
                });
                html = html.concat(this.resetButton());
                this.formSubmission.innerHTML = html;
                this.resetForm();
            }
            
        });
    }

    toggleFormContainer = () => {
        this.formHidden = !this.formHidden;
        this.form.hidden = this.formHidden;
        this.formSubmission.style.visibility = this.formHidden ? 'visible':'hidden';
    }

    buildContent = (input) => {
        return `<div><span style="font-weight:bold">${input.name}: </span><span>${input.value}</span></div>`
    }

    resetButton = () => {
        return `<button id="reset" type="reset" href="javascript:void">Add Another</button>`;
    }

    resetForm = () => {
        this.reset = document.getElementById('reset') as HTMLButtonElement;
        this.reset.addEventListener('click', e => {
            e.preventDefault();
            this.formHidden = !this.formHidden;
            this.formSubmission.innerHTML = "";
            this.formSubmission.style.visibility = 'hidden';
            this.form.hidden = this.formHidden;
            this.form.reset();
        })
    }
}


const validator = new Validator();
validator.initialize()