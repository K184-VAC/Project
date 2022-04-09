import { computed, Ref, toRef, WritableComputedRef } from "vue";

export function autoFormComputed<
  FormType extends object,
  PropKeyType extends keyof FormType,
  ModeledType extends FormType[PropKeyType]
>(
  modelValue: Ref<FormType>,
  emit: { (event: "update:modelValue", value: FormType): void },
  propName: PropKeyType,
  defaultValue: ModeledType
): WritableComputedRef<ModeledType> {
  const propRef = toRef(modelValue.value, propName);
  return computed<ModeledType>({
    get: () => propRef.value || defaultValue,
    set: (value) => {
      modelValue.value[propName] = value;
      emit("update:modelValue", modelValue.value);
    },
  });
}
