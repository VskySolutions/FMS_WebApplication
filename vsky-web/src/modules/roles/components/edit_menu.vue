<template>
  <q-dialog v-model="small" ref="dialogRef" persistent @hide="onDialogHide" position="right">
    <q-card class="q-dialog-plugin dialog-md">
      <q-card-section class="card-header with-tools">
        <div class="text-h2">{{ id ? "Edit" : "Add" }} Menu</div>
        <q-btn v-close-popup icon="o_close" class="close" flat round dense />
      </q-card-section>
      <q-separator />
      <q-form greedy @submit.prevent.stop="onSubmit">
        <q-card-section class="card-body scroll">
          <div class="row q-col-gutter-x-md">
            <div class="col-6">
              <div class="form-group">
                <q-input
                  v-model="model.displayName" label="Menu Name" outlined stack-label hide-bottom-space :dense="false" maxlength="128" autofocus
                  :error="v$.displayName.$error" :error-message="v$.displayName.$errors[0]?.$message" @blur="v$.displayName.$touch" @change="onDisplayNameChange()"
                />
              </div>
            </div>
             <div class="col-6">
              <div class="form-group">
                <q-input
                  v-model="model.menuName" label="Menu Prefix" outlined stack-label hide-bottom-space :dense="false" maxlength="128" autofocus readonly
                />
              </div>
            </div>
          </div>
            <div class="row q-col-gutter-x-md">
            <div class="col-6">
              <div class="form-group">
                <q-input
                  v-model="model.sortorder" label="Sortorder" outlined stack-label hide-bottom-space :dense="false" maxlength="128" autofocus
                  :error="v$.sortorder.$error" :error-message="v$.sortorder.$errors[0]?.$message" @blur="v$.sortorder.$touch"
                />
              </div>
            </div>
          </div>
          <div class="q-gutter-md">
            <q-checkbox v-model="model.active" label="Active" dense />
          </div>
        </q-card-section>
        <q-separator />
        <q-card-actions align="right">
          <q-btn color="primary" label="Cancel" flat no-caps @click="onDialogCancel" />
          <q-btn color="primary" label="Save Changes" type="submit" :loading="processing" no-caps />
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
const parentMenus = ref([]);

const model = ref({
  menuName: "",
  displayName: "",
  sortorder: "",
  parentMenuId: "",
  moduleId: "",
  active: false
});

const props = defineProps({ id: { type: String, default: "" } });

const rules = {
  displayName: { required: helpers.withMessage("Menu name is required", required) },
  sortorder: { required: helpers.withMessage("Sortorder is required", required) },
  moduleId: { required: helpers.withMessage("Module is required", required) }
};

const v$ = useVuelidate(rules, model, { $lazy: true, $autoDirty: true });

const onDisplayNameChange = () => {
  if (!props.id) {
    model.value.menuName = "M-" + model.value.displayName.toLowerCase().trim().replace(/\s+/g, "-");
  }
};

const getParentMenuList = () => {
  loading.value = true;
  roleService.getParentMenus().then((resp) => {
    const responseData = resp.map((item) => ({ text: item.displayName, value: item.id }));
    parentMenus.value = responseData;
  }).finally(() => {
    loading.value = false;
  });
};

const getMenu = () => {
  loading.value = true;
  roleService.getMenu(props.id).then((resp) => {
    model.value = _.cloneDeep(resp);
  }).finally(() => {
    loading.value = false;
  });
};

watch(() => props.id, (newValue, oldValue) => {
  getParentMenuList();
  if (newValue) {
    getMenu();
  }
}, { immediate: true });

const onSubmit = async () => {
  if (await v$.value.$validate()) {
    processing.value = true;
    roleService.saveMenu(props.id, model.value).then((resp) => {
      notifySuccess({ message: "Menu is saved successfully." });
      onDialogOK();
    }).finally(() => {
      processing.value = false;
    });
  }
};
</script>
