class Validator {
    constructor() {
        this.fields = ["Name", "FunFact"];
        this.validate = () => {
            this.form.addEventListener('submit', e => {
                e.preventDefault();
                const invalids = [];
                const valids = [];
                Array.from(this.form.elements).forEach(field => {
                    var source = field;
                    if (this.fields.indexOf(source.name) > -1) {
                        var result = source.checkValidity();
                        if (!result) {
                            invalids.push(source.name);
                        }
                        else {
                            valids.push({ name: source.name, value: source.value });
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
                        console.log(v);
                        html = html.concat(this.buildContent(v));
                    });
                    html = html.concat(this.resetButton());
                    this.formSubmission.innerHTML = html;
                    this.resetForm();
                }
            });
        };
        this.toggleFormContainer = () => {
            this.formHidden = !this.formHidden;
            this.form.hidden = this.formHidden;
            this.formSubmission.style.visibility = this.formHidden ? 'visible' : 'hidden';
        };
        this.buildContent = (input) => {
            return `<span style="font-weight:bold">${input.name}: </span><span>${input.value}</span><br/>`;
        };
        this.resetButton = () => {
            return `<button id="reset" type="reset" href="javascript:void">Add Another</button>`;
        };
        this.resetForm = () => {
            this.reset = document.getElementById('reset');
            this.reset.addEventListener('click', e => {
                e.preventDefault();
                this.formHidden = !this.formHidden;
                this.formSubmission.innerHTML = "";
                this.formSubmission.style.visibility = 'hidden';
                this.form.hidden = this.formHidden;
                this.form.reset();
            });
        };
        this.form = document.getElementById('introduction-form');
        this.formSubmission = document.getElementById('form-submission');
        this.formHidden = false;
    }
    initialize() {
        this.validate();
    }
}
const validator = new Validator();
validator.initialize();
//# sourceMappingURL=form.js.map