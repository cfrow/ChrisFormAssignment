<template>
    <div>
        <b-container>
            <b-row>
                <h1 class="mb-4"><strong>Contact Us Form</strong></h1>
                <b-form @submit="onSubmit" v-if="showForm">
                    <b-form-group id="first-name-group" label="First Name" label-for="first-name">
                        <b-form-input id="first-name" v-model="form.firstName" type="text" required />
                    </b-form-group>

                    <b-form-group id="last-name-group" label="Last Name" label-for="last-name">
                        <b-form-input id="last-name" v-model="form.lastName" type="text" required />
                    </b-form-group>

                    <b-form-group id="email-group" label="Email" label-for="email">
                        <b-form-input id="email" v-model="form.email" type="email" required />
                    </b-form-group>

                    <b-form-group id="message-group" label="Message" label-for="message">
                        <b-form-textarea id="message" v-model="form.message" rows="6" required />
                    </b-form-group>

                    <b-button class="mt-4" type="submit" :disabled="actionLoading">
                        <b-spinner v-if="actionLoading" class="spinner" small type="grow"></b-spinner>
                        <span>{{actionLoading ? 'SUBMITTING...' : 'SUBMIT'}}</span>
                    </b-button>
                </b-form>
            </b-row>
        </b-container>

        <b-alert v-model="submissionSuccess" class="position-fixed fixed-bottom m-0 rounded-0 text-center" fade variant="success">Your information was submitted successfully.</b-alert>
        <b-alert v-model="submissionFail" class="position-fixed fixed-bottom m-0 rounded-0 text-center" fade variant="danger">Something went wrong during submission. Please try again.</b-alert>
    </div>
</template>

<script>
    import contactForm from '../classes/contactForm';
    import axios from 'axios';

    export default {
        name: 'ContactForm',
        data() {
            return {
                showForm: true,
                submissionSuccess: false,
                submissionFail: false,
                http: null,
                actionLoading: false,
                form: new contactForm()
            }
        },
        mounted: function () {
            this.http = axios.create({
                baseURL: 'https://localhost:44330/api/'
            });
        },
        methods: {
            async onSubmit(event) {
                event.preventDefault();
                this.actionLoading = true;

                try {
                    await this.http.post('contactForm', this.form);

                    this.resetForm();
                    this.actionLoading = false;
                    this.submissionResult('success');
                } catch {
                    this.actionLoading = false;
                    this.submissionResult('fail');
                }
            },
            resetForm() {
                this.form = new contactForm();

                this.showForm = false;
                this.$nextTick(() => {
                    this.showForm = true;
                })
            },
            submissionResult(status) {
                status === 'success' ? this.submissionSuccess = true : this.submissionFail = true;

                setTimeout(() => {
                    this.submissionSuccess = false;
                    this.submissionFail = false;
                }, 5000);
            }
        }
    }
</script>

<style scoped>
    .container {
        max-width: 720px;
    }

    h1 {
        font-size: 38px;
    }

    ::v-deep label {
        font-size: 16px;
        margin-bottom: 3px;
    }

    form div {
        margin-bottom: 15px;
    }

    form input {
        background: var(--white);
        border-color: var(--blue);
        height: 36px;
        font-size: 16px;
        font-family: Arial, sans-serif;
    }

    form textarea {
        background: var(--white);
        border-color: var(--blue);
        font-size: 16px;
        font-family: Arial, sans-serif;
    }

    button {
        height: 36px;
        font-size: 16px;
        width: 100%;
        background: var(--blue);
        color: var(--white);
    }

    .spinner {
        margin-right: 10px;
    }

    .btn:hover {
        background-color: #1997B7;
    }

    .btn-secondary:disabled, .btn-secondary.disabled {
        background: var(--blue);
    }

    ::v-deep .form-control {
        color: var(--text) !important;
    }
</style>
