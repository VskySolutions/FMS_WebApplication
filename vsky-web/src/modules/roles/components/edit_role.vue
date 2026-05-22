<template>
  <q-dialog v-model="small" ref="dialogRef" persistent @hide="onDialogHide" class="edit_role">
    <q-card style="width:700px; max-width:95vw" class="mainCard">
      <q-card-section class="card-header with-tools">
        <div class="text-h2">{{ id ? "Edit" : "Add" }} Role</div>
        <q-btn v-close-popup icon="o_close" class="close" flat round dense />
      </q-card-section>
      <q-separator />
      <q-form greedy @submit.prevent.stop="onSubmit">
        <q-card-section class="card-body scroll">
          <div class="row q-col-gutter-x-md">
            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
              <div class="form-group">
                <q-input
                  v-model="model.name" label="Role Name" outlined stack-label hide-bottom-space :dense="false" maxlength="128" autofocus
                  :error="v$.name.$error" :error-message="v$.name.$errors[0]?.$message" @blur="v$.name.$touch"
                />
              </div>
            </div>
          </div>
        </q-card-section>
        <q-separator />
        <q-card-actions align="right">
          <q-btn color="primary" label="Cancel" flat no-caps @click="onDialogCancel" />
          <q-btn class="bg-pink-3 rounded-corners" label="Save Changes" type="submit" :loading="processing" no-caps />
        </q-card-actions>
      </q-form>
    </q-card>
  </q-dialog>
</template>

<script setup>
import { useDialogPluginComponent } from "quasar";
import useVuelidate from "@vuelidate/core";
import { required, helpers } from "@vuelidate/validators";
import { ref, watch } from "vue";
import _ from "lodash";
import roleService from "modules/roles/role.service";
import { notifySuccess } from "assets/utils";

defineEmits([...useDialogPluginComponent.emits]);
const { dialogRef, onDialogHide, onDialogOK, onDialogCancel } = useDialogPluginComponent();

const loading = ref(false);
const processing = ref(false);

const model = ref({
  name: ""
});

const props = defineProps({ id: { type: String, default: "" } });

const rules = {
  name: { required: helpers.withMessage("Role name is required", required) }
};

const v$ = useVuelidate(rules, model, { $lazy: true, $autoDirty: true });

const getRole = () => {
  loading.value = true;
  roleService.getRole(props.id).then((resp) => {
    model.value = _.cloneDeep(resp);
  }).finally(() => {
    loading.value = false;
  });
};

watch(() => props.id, (newValue, oldValue) => {
  if (newValue) {
    getRole();
  }
}, { immediate: true });

const onSubmit = async () => {
  if (await v$.value.$validate()) {
    processing.value = true;
    roleService.saveRole(props.id, model.value).then((resp) => {
      notifySuccess({ message: "Role is saved successfully." });
      onDialogOK();
    }).finally(() => {
      processing.value = false;
    });
  }
};
</script>
